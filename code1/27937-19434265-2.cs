    @using (Ajax.BeginForm("CreateContent", "MyController", new { contentOwnerId = Model.ContentOwnerId }))
    {
        @Html.AntiForgeryToken()
        @Html.HiddenFor(x => x.ContentOwnerId)
    
        <!-- Rest of your form controls -->
        <input name="SaveDraft" type="submit" value="SaveDraft" />
        <input name="Publish" type="submit" value="Publish" />
    }
