    public static async Task<HttpCall> Replay(this HttpCall call)
    {
        call.Response = await call.FlurlRequest.SendAsync(call.Request.Method, call.Request.Content);
        return call;
    }
