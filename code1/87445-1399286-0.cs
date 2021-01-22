    if (IsSecure && !Request.IsSecureConnection)
    {
        string targetUrl = String.Format(
                               "https://{0}{1}",
                               Request.Url.Host,
                               Request.RawUrl);
        Response.Redirect(targetUrl);
    }
    else if (!IsSecure && Request.IsSecureConnection)
    {
        string targetUrl = String.Format(
                               "http://{0}{1}", 
                               Request.Url.Host, 
                               Request.RawUrl);
        Response.Redirect(targetUrl);
    }
