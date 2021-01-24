       // Asynchronously downloads the requested resource as a string.
       public static async Task<string> DownloadStringAsync(string address)
       {
          // First try to retrieve the content from cache.
          string content;
          if (cachedDownloads.TryGetValue(address, out content))
          {
             return content;
          }
    
          content = await new WebClient().DownloadStringTaskAsync(address);
          cachedDownloads.TryAdd(address, content);
          return content;
       }
