﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    using System;
    
    #line 2 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class RetriesPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\Dashboard\Pages\RetriesPage.cshtml"
  
    Layout = new LayoutPage("Retries");
    
    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    Pager pager;
    List<string> jobIds;

    using (var connection = Storage.GetConnection())
    {
        var storageConnection = connection as JobStorageConnection;
        
        pager = new Pager(from, perPage, storageConnection.GetSetCount("retries"));
        jobIds = storageConnection.GetRangeFromSet("retries", pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h1 class=\"page-header\"" +
">Retries</h1>\r\n");


            
            #line 31 "..\..\Dashboard\Pages\RetriesPage.cshtml"
         if (jobIds.Count == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-success\">\r\n                All is OK – you ha" +
"ve no retries.\r\n            </div>\r\n");


            
            #line 36 "..\..\Dashboard\Pages\RetriesPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\r\n                <div class=\"btn-toolbar b" +
"tn-toolbar-top\">\r\n                    <button class=\"js-jobs-list-command btn bt" +
"n-sm btn-primary\"\r\n                            data-url=\"");


            
            #line 42 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                 Write(Url.To("/jobs/scheduled/enqueue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Enqueueing...""
                            disabled=""disabled"">
                        <span class=""glyphicon glyphicon-repeat""></span>
                        Enqueue jobs
                    </button>

                    <button class=""js-jobs-list-command btn btn-sm btn-default""
                            data-url=""");


            
            #line 50 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                 Write(Url.To("/jobs/scheduled/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Deleting...""
                            data-confirm=""Do you really want to DELETE ALL selected jobs?""
                            disabled=""disabled"">
                        <span class=""glyphicon glyphicon-remove""></span>
                        Delete selected
                    </button>

                    ");


            
            #line 58 "..\..\Dashboard\Pages\RetriesPage.cshtml"
               Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral(@"
                </div>

                <table class=""table table-hover"">
                    <thead>
                    <tr>
                        <th class=""min-width"">
                            <input type=""checkbox"" class=""js-jobs-list-select-all""/>
                        </th>
                        <th class=""min-width"">Id</th>
                        <th class=""min-width"">State</th>
                        <th>Job</th>
                        <th>Reason</th>
                        <th class=""align-right"">Retry</th>
                        <th class=""align-right"">Created</th>
                    </tr>
                    </thead>
                    <tbody>
");


            
            #line 76 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                     foreach (var jobId in jobIds)
                    {
                        JobData jobData;
                        StateData stateData;

                        using (var connection = Storage.GetConnection())
                        {
                            jobData = connection.GetJobData(jobId);
                            stateData = connection.GetStateData(jobId);
                        }


            
            #line default
            #line hidden
WriteLiteral("                        <tr class=\"js-jobs-list-row ");


            
            #line 87 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                Write(jobData != null ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <td>\r\n                                <input type" +
"=\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 89 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                                                                     Write(jobId);

            
            #line default
            #line hidden
WriteLiteral("\"/>\r\n                            </td>\r\n                            <td class=\"mi" +
"n-width\">\r\n                                ");


            
            #line 92 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                           Write(Html.JobIdLink(jobId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n");


            
            #line 94 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                             if (jobData == null)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <td colspan=\"5\"><em>Job expired.</em></td>\r\n");


            
            #line 97 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                            }
                            else
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <td class=\"min-width\">\r\n                         " +
"           ");


            
            #line 101 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                               Write(Html.StateLabel(jobData.State));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");



WriteLiteral("                                <td>\r\n                                    ");


            
            #line 104 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                               Write(Html.JobNameLink(jobId, jobData.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");



WriteLiteral("                                <td>\r\n                                    ");


            
            #line 107 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                Write(stateData != null ? stateData.Reason : null);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");



WriteLiteral("                                <td class=\"align-right\">\r\n");


            
            #line 110 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                     if (stateData != null && stateData.Data.ContainsKey("EnqueueAt"))
                                    {
                                        
            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                   Write(Html.RelativeTime(JobHelper.DeserializeDateTime(stateData.Data["EnqueueAt"])));

            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                                                                                      
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n");



WriteLiteral("                                <td class=\"align-right\">\r\n                       " +
"             ");


            
            #line 116 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                               Write(Html.RelativeTime(jobData.CreatedAt));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");


            
            #line 118 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tr>\r\n");


            
            #line 120 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n                ");


            
            #line 124 "..\..\Dashboard\Pages\RetriesPage.cshtml"
           Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 126 "..\..\Dashboard\Pages\RetriesPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
