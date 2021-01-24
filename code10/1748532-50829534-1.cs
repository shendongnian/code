    /// <summary>
    /// APIs returning HttpWebResponse must be explicitly Disposed, e.g using (var res = client.Post(url)) { ... }
    /// </summary>
    [Obsolete("Use: using (client.Post<HttpWebResponse>(requestDto) { }")]
    public virtual HttpWebResponse Post(object requestDto)
    {
        return Send<HttpWebResponse>(HttpMethods.Post, ResolveTypedUrl(HttpMethods.Post, requestDto), requestDto);
    }
