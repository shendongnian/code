    private async Task SendHTTPResponse(HttpContext context, HttpResponseMessage responseMessage)
    {
        context.Response.StatusCode = (int)responseMessage.StatusCode;
    
        foreach (var header in responseMessage.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }
    
        foreach (var header in responseMessage.Content.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }
    
        context.Response.Headers.Remove("transfer-encoding");
    
        using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
        {
           return responseStream.CopyToAsync(context.Response.Body);
        }
    
    }
    
    public async Task ForwardRequestAsync(string toHost, HttpContext context)
    {
    
        var requestMessage = this.BuildHTTPRequestMessage(context);
        var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted);
        return this.SendHTTPResponse(context, responseMessage);
    }
