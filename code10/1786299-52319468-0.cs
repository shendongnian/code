    string requestedPath = HttpUtility.UrlDecode(this.StripLanguage(currentContext.InputUrl.AbsolutePath));
    string requestedPathAndQuery = HttpUtility.UrlDecode(currentContext.InputUrl.PathAndQuery);
    string requestedRawUrl = HttpUtility.UrlDecode(currentContext.InputUrl.PathAndQuery);
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
    var finalRequestedURL = regex.IsMatch(requestedPathAndQuery)
                        ? requestedPathAndQuery
                        : regex.IsMatch(requestedPath)
                            ? requestedPath
                            : regex.IsMatch(requestedPathWithCulture)
                                ? requestedPathWithCulture
                                : regex.IsMatch(requestedRawUrl)
                                    ? requestedRawUrl
                                    : regex.IsMatch(requestedUrl)
                                        ? requestedRawUrlDomainAppended
                                        : string.Empty;
