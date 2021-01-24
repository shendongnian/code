    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        private bool ShouldLog(IDictionary<string, IEnumerable<string>> headers)
        {
            if (headers.TryGetValue("Content-Type", out IEnumerable<string> values))
            {
                if (values.Any(x => x == "application/json"))
                    return true;
            }
            return false;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            if (ShouldLog(request.Headers.ToDictionary(x => x.Key, x => x.Value)))
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                LogUtil.Info("[" + request.GetCorrelationId() + "] Call:" + request.RequestUri, "httpTrace");
                if (!string.IsNullOrEmpty(requestBody))
                    LogUtil.Info(requestBody, "httpTrace");
            }
            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);
            if (result.Content != null)
            {
                if (ShouldLog(result.Headers.ToDictionary(x => x.Key, x => x.Value)))
                {
                    // once response body is ready, log it
                    var responseBody = await result.Content.ReadAsStringAsync();
                    //LogUtil.Info(responseBody,"httpTrace");
                    LogUtil.Info("[" + request.GetCorrelationId().ToString() + "] Return:" + responseBody, "httpTrace");
                }
            }
            return result;
        }
        
    }
