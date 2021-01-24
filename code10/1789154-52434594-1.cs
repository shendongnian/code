    if (context.Request.IsHttps || !TryGetHttpsPort(out var port))
    {
        return _next(context);
    }
    var host = context.Request.Host;
    if (port != 443)
    {
        host = new HostString(host.Host, port);
    }
    else
    {
        host = new HostString(host.Host);
    }
    var request = context.Request;
    var redirectUrl = UriHelper.BuildAbsolute(
        "https",
        host,
        request.PathBase,
        request.Path,
        request.QueryString);
    context.Response.StatusCode = _statusCode;
    context.Response.Headers[HeaderNames.Location] = redirectUrl;
    _logger.RedirectingToHttps(redirectUrl);
    return Task.CompletedTask;
