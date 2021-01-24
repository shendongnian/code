    string requestedPath = HttpUtility.UrlDecode(this.StripLanguage(currentContext.InputUrl.AbsolutePath));
    string requestedPathAndQuery = HttpUtility.UrlDecode(currentContext.InputUrl.PathAndQuery);
    // This string is identical to requestPathAndQuery, so I am removing it
    // string requestedRawUrl = HttpUtility.UrlDecode(currentContext.InputUrl.PathAndQuery);
    string requestedUrl =
        HttpUtility.UrlDecode(
            string.Concat(
                currentContext.InputUrl.Scheme,
                "://",
                currentContext.InputUrl.Host,
                requestedRawUrl));
    
    string requestedRawUrlDomainAppended = HttpUtility.UrlDecode(currentContext.InputUrl.AbsoluteUri);
    string requestedPathWithCulture = HttpUtility.UrlDecode(currentContext.InputUrl.AbsolutePath);
    
    var regex = new Regex(matchPattern.Trim(), RegexOptions.IgnoreCase);
    var finalRequestedURL = string.Empty;
    // You could even add in brackets here to aid readability but this
    // helps remove the indententation/nesting that makes the code harder
    // to read and follow
    if (regex.IsMatch(requestedPathAndQuery)) finalRequestURL = requestedPathAndQuery;
    else if(regex.IsMatch(requestedPath)) finalRequestURL = requestedPath;
    else if (regex.IsMatch(requestedPathWithCulture)) finalRequestURL = requestedPathWithCulture;
    else if (regex.IsMatch(requestedUrl)) finalRequestURL = requestedRawUrlDomainAppended;
