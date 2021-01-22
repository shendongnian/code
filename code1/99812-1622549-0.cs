    string uriString = "...";
    Uri uri;
    if (!Uri.TryCreate(uriString, UriKind.Absolute, out uri))
    {
        // Uri is totally invalid!
    }
    else
    {
        // validate the scheme
        if (!uri.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
        {
            // not http!
        }
        // validate the authority ('www.blah.com:1234' portion)
        if (uri.Authority // ...)
        {
        }
        // ...
    }
