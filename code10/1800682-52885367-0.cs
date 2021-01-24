    /// <summary>
    /// Verify if the request is valid, then returns LINE Webhook events from the request
    /// </summary>
    /// <param name="request">HttpRequestMessage</param>
    /// <param name="channelSecret">ChannelSecret</param>
    /// <returns>List of WebhookEvent</returns>
    public static async Task<IEnumerable<WebhookEvent>> GetWebhookEventsAsync(this HttpRequestMessage request, string channelSecret)
    {
        if (request == null) { throw new ArgumentNullException(nameof(request)); }
        if (channelSecret == null) { throw new ArgumentNullException(nameof(channelSecret)); }
        var content = await request.Content.ReadAsStringAsync();
        var xLineSignature = request.Headers.GetValues("X-Line-Signature").FirstOrDefault();
        if (string.IsNullOrEmpty(xLineSignature) || !VerifySignature(channelSecret, xLineSignature, content))
        {
            throw new InvalidSignatureException("Signature validation faild.");
        }
        return WebhookEventParser.Parse(content);
    }
