    static ConcurrentDictionary<string, string> cachedDownloads =
      new ConcurrentDictionary<string, string>();
    // Asynchronously downloads the requested resource as a string.
    public static Task<string> DownloadStringAsync(string address)
    {
      // First try to retrieve the content from cache.
      string content;
      if (cachedDownloads.TryGetValue(address, out content))
      {
         return Task.FromResult<string>(content);
      }
      // If the result was not in the cache, download the 
      // string and add it to the cache.
      return Task.Run(async () =>
      {
         content = await new WebClient().DownloadStringTaskAsync(address);
         cachedDownloads.TryAdd(address, content);
         return content;
      });
