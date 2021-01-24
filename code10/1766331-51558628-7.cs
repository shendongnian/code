       // Asynchronously downloads the requested resource as a string.
       public static Task<string> DownloadStringAsync(string address)
       {
          // First try to retrieve the content from cache.
          string content;
          if (cachedDownloads.TryGetValue(address, out content))
          {
             return Task.FromResult(content);
          }
    
          return DownloadStringSlowAsync(address);
       }
       private static async Task<string> DownloadStringSlowAsync(string address)
       {
          string content = await new WebClient().DownloadStringTaskAsync(address);
          cachedDownloads.TryAdd(address, content);
          return content;
       }
