    <div class="panel-title createLink">
        @if (Model.Termination > DateTime.Now)
        {
            // add
            <a href="#" title="your tooltip" id="createSideLetterLink" style="background-color:red">
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
