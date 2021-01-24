    public HttpResponse<TResponse> SubmitRequest<TResponse>(string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header)
    {
        string RawResponse = "";
        HttpResponse<TResponse> Response = new HttpResponse<TResponse>(new TResponse(), RawResponse, System.Net.HttpStatusCode.Created);
        return Response;
    }
