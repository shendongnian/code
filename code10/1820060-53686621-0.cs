    /// <summary>
    ///     Assembles URL to call based on parameters, method and resource
    /// </summary>
    /// <param name="request">RestRequest to execute</param>
    /// <returns>Assembled System.Uri</returns>
    public Uri BuildUri(IRestRequest request)
    {
        DoBuildUriValidations(request);
        var applied = GetUrlSegmentParamsValues(request);
        string mergedUri = MergeBaseUrlAndResource(applied.Uri, applied.Resource);
        string finalUri = ApplyQueryStringParamsValuesToUri(mergedUri, request);
        return new Uri(finalUri);
    }
