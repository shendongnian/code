    public static class HttpActionResultExtentions
    {
        public static IHttpActionResult AddHeader(this IHttpActionResult result, string name, IEnumerable<string> values)
            => new HeaderActionResult(result, name, values);
    private class HeaderActionResult : IHttpActionResult
        {
            private readonly IHttpActionResult actionResult;
    
            private readonly Tuple<string, IEnumerable<string>> header;
    
            public HeaderActionResult(IHttpActionResult actionResult, string headerName, IEnumerable<string> headerValues)
            {
                this.actionResult = actionResult;
    
                header = Tuple.Create(headerName, headerValues);
            }
    
            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = await actionResult.ExecuteAsync(cancellationToken);
    
                response.Headers.Add(header.Item1, header.Item2);
    
                return response;
            }
        }
    }
