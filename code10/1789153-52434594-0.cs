    if (!context.HttpContext.Request.IsHttps)
    {
        var host = context.HttpContext.Request.Host;
        if (SSLPort.HasValue && SSLPort.Value > 0)
        {
            // a specific SSL port is specified
            host = new HostString(host.Host, SSLPort.Value);
        }
        else
        {
            // clear the port
            host = new HostString(host.Host);
        }
        var req = context.HttpContext.Request;
        var newUrl = new StringBuilder().Append("https://").Append(host).Append(req.PathBase).Append(req.Path).Append(req.QueryString);
        var response = context.HttpContext.Response;
        response.StatusCode = StatusCode;
        response.Headers[HeaderNames.Location] = newUrl.ToString();
        context.Result = RuleResult.EndResponse;
        context.Logger?.RedirectedToHttps();
    }
