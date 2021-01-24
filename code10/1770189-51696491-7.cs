    @model List<YourNamespace.Post>
    <div>
        @foreach (var item in Model)
        {
            <h4>@item.Title<h4>
            <h5>@Html.ActionLink("Edit", "Edit",
                           new { id = item.Id, SPHostUrl = ViewBag.SPHostUrl },
                           new { @class = "badge badge-primary editIRFBut" }) 
            </h5>    
        }
    </div>
