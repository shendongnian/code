    // parameter key
    private static readonly string ReturnUrlParameter = "ReturnUrl";
    
    protected void Application_EndRequest(object sender, EventArgs e)
    {
        if (Response.IsRequestBeingRedirected)
        {
            Uri redirectUrl;
            if (Uri.TryCreate(Response.RedirectLocation, UriKind.RelativeOrAbsolute, out redirectUrl))
            {
                redirectUrl = MakeAbsoluteUriIfNecessary(redirectUrl);
                Uri currentUrl = Request.Url;
                var currentQueryParameters = 
    					HttpUtility.ParseQueryString(HttpUtility.UrlDecode(currentUrl.Query));
                // the parameter is present in the current url already
                if (currentQueryParameters[ReturnUrlParameter] != null)
                {
                    UriBuilder builder = new UriBuilder(redirectUrl);
                    builder.Query = 
    						HttpUtility.UrlDecode(builder.Query)
    							.Replace(Request.Url.Query, string.Empty).TrimStart('?');
    
                    Response.RedirectLocation = 
    						Request.Url.MakeRelativeUri(builder.Uri).ToString();
                }
            }
        }
    }
    
    private Uri MakeAbsoluteUriIfNecessary(Uri url)
    {
        if (url.IsAbsoluteUri)
        {
            return url;
        }
        else 
        {
            Uri currentUrl = Request.Url;
            UriBuilder builder = new UriBuilder(
    				currentUrl.Scheme, 
    				currentUrl.Host, 
    				currentUrl.Port
    			);
    
            return new Uri(builder.Uri, url);
        }
    }
