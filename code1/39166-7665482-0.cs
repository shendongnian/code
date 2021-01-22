    // ensure we send credentials over a secure connection
    if (!HttpContext.Current.Request.IsSecureConnection)
    {
         string postbackUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https");
         LinkButton_Login.PostBackUrl = postbackUrl;
    }
