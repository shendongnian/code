    if (IsSecure && Request.Url.Scheme == "http")
    {
        string targetUrl = String.Format(
                               "https://{0}{1}",
                               Request.Url.Host,
                               Request.RawUrl);
        Response.Redirect(targetUrl);
    }
    else if (!IsSecure && Request.Url.Scheme == "https")
    {
        string targetUrl = String.Format(
                               "http://{0}{1}", 
                               Request.Url.Host, 
                               Request.RawUrl);
        Response.Redirect(targetUrl);
    }
