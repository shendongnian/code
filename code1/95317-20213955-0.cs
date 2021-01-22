    /// <summary>
    /// Builds real URL considering layouts pages.
    /// </summary>
    private Uri CurrentUrl
    {
        get
        {
            return Request.Url.ToString().ToLower().Contains("_layouts")
                ? new Uri(
                    SPContext.Current.Site.WebApplication.GetResponseUri(
                        SPContext.Current.Site.Zone).ToString().TrimEnd('/')
                    + Request.RawUrl) 
                : Request.Url;
        }
    }
