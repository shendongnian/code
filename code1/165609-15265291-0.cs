    <html>
    <form action="/SubmitReportList">
                @{Html.Grid((List<NetSheet.Models.Report>)ViewData["ReportList"])
           .Sort((GridSortOptions)ViewData["sort"])
           .Attributes(id => "grid", @class => "grid")
    
           .Columns(column =>
           {
               	column.For(c => Html.CheckBox("chkSelected", new { @class = "gridCheck",   @value = c.ReportId }))
               	.Named("").Encode(false)
               	.Attributes(@class => "grid-column");
    
                              
    column.For(c => c.ReportName)
                  .Named("Buyer Close Sheet Name")
                  .SortColumnName("ReportName")
                   .Attributes(@class => "grid-column");
               
           })
           .Render();}
    
    <input type="submit" name=" DeleteReports" id=" DeleteReports" value="Delete" class="btnSubmit"/>
    
    </form>
    </html>
