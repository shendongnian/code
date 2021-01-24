    <div class="panel-title createLink">
        @if (Model.OriginalContract.SummaryInfo.TerminationDate > DateTime.Now)
        {
            // Set a tooltip and class
            <a href="#" title="your tooltip" id="createSideLetterLink"  class="your-class">
                <span class="fa fa-file"></span>&nbsp; Create Side Letter
            </a>
        }
        else
        {
            <a href="@Url.Action("CreateSideLetter", "ClientSetup", new
                 {
                     page = Model.PagingInfo.Page,
                     take = Model.PagingInfo.Take,
                     sortBy = Model.PagingInfo.SortPropertyName,
                     sortAsc = Model.PagingInfo.SortAscending
                })" data-container="body" data-toggle="tooltip" title="Add Side Letter" id="createSideLetterLink">
                <span class="fa fa-file"></span>&nbsp; Create Side Letter
            </a>
        }
    </div>
