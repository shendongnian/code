    public override Stream GetResponseStream()
    {
        CheckDisposed();
        return _httpResponseMessage.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
    }
