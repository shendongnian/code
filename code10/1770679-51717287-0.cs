    IHttpContextAccessor context; // injected
    var request = context.HttpContext.Request;
	var uriBuilder = new UriBuilder();
	uriBuilder.Scheme = request.Scheme;
	uriBuilder.Host = request.Host.Host;
	if (request.Host.Port.HasValue)
	{
		uriBuilder.Port = request.Host.Port.Value;
	}
	uriBuilder.Path = request.Path;
	if (request.QueryString.HasValue)
	{
		uriBuilder.Query = request.QueryString.Value.Substring(1);
	}
    var requestUri = uriBuilder.Uri;
