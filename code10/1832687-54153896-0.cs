    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
        response.Content = new StringContent(Content);
        response.RequestMessage = Request;
        return Task.FromResult(response);
    }
