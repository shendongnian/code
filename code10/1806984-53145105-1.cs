    [FunctionName("Tenant")]
    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Tenant/{DomainName}")]HttpRequestMessage req, string DomainName, [Inject(typeof(ITableOps))]ITableOps _tableOps, TraceWriter log)
    {
        var headers = req.Headers;
        var apiKey = headers.GetValues("apiKey").First();
        var domain = headers.GetValues("domain").First();
        //Do something with apiKey and domain here.
        var settings = _tableOps.GetTenantSettingsAsync(DomainName);
        return req.CreateResponse(HttpStatusCode.OK, settings.Result);
    }
