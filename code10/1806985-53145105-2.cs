    [FunctionName("Tenant")]
    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Tenant/{DomainName}")]HttpRequestMessage req, string DomainName, [Inject(typeof(ITableOps))]ITableOps _tableOps, TraceWriter log)
    {
        var headers = req.Headers;
        if(!headers.TryGetValues("apiKey", out var apiKeys) ||
           !headers.TryGetValues("domain", out var domains))
        {
            return req.CreateResponse(HttpStatusCode.Forbidden);
        }
        var apiKey = apiKeys.First();
        var domain = domains.First();
        //Do something with apiKey and domain here.
        var settings = _tableOps.GetTenantSettingsAsync(DomainName);
        return req.CreateResponse(HttpStatusCode.OK, settings.Result);
    }
