    private T CreateQueryOptions<T>(string url, [CallerMemberName] string caller = null) where T : class
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
        ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<T>(caller);
        var odata =  new ODataQueryOptions<T>(new ODataQueryContext(modelBuilder.GetEdmModel(), typeof(T)), httpRequest);
        // rest of your code here to validate OData parameters  Generics may not be appropriate for you.
    }
