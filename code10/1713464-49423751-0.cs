    public HttpResponseMessage GetWithParameters(String path, Dictionary<string, string> urlParameters)
    {
    String parameters = BuildURLParametersString(urlParameters);
    HttpResponseMessage response = httpClient.GetAsync(path + parameters).Result;
    return response;
    }
    
    private String BuildURLParametersString(Dictionary<string, string> parameters)
    {
    UriBuilder uriBuilder = new UriBuilder();
    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
    foreach (var urlParameter in parameters)
    {
    query[urlParameter.Key] = urlParameter.Value;
    }
    uriBuilder.Query = query.ToString();
    return uriBuilder.Query;
    }
