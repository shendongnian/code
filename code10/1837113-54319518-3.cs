    @model IEnumerable<GroupComment>
    @{
       var comment = Model;    
       foreach (var c in comment)
       {
           if (c.COMMENT_ID > 0)
           {
          <div>
           <img src="~/Content/note.jpg" /><span 
            class="comment">@Html.ActionLink("Edit", "Edit", "Comments", new { id = 
          c.COMMENT_ID }, null)</span> @c.COMMENTS
         </div>
            } else {
            <div>
                @Html.ActionLink("Add \u00BB", "Create", "Comments", new { NCR_REQUEST_ID = c.NCR_REQUEST_ID, NCR_GROUPS_ID = c.NCR_GROUPS_ID }, new { @class = "btn btn-primary btn-sm" })
            </div>
        }
    }       
}
