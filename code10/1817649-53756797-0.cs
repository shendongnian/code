    if(this._urlService.Action() == null) //same urlHelper action, only has default Home page values passed into method
    {
        var query = string.Empty;
        if(Request.QueryString.HasValue)
        {
            query = Request.QueryString.Value;
        }
        var path = "/Home/NotFound" + query;
        path = string.Concat("/", this._userIdentity.CurrentLanguage.ToString().ToLower(), path);
        return base.Redirect(path);
     }
