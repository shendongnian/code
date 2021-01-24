        private async Task DownloadAsync()
        {
           using (var wc = new GZipWebClient())
           {
              // this html sometimes contain <title> with error message
              html = await wc.DownloadStringTaskAsync(url);
    
              if (html.Contains("My Error Message")) 
              {
                  // Log Error
                  throw new MyDownloadFailedException(html);
              }
          }
       }
    
       // In your calling method
       var p = Policy
                .Handle<MyDownloadFailedException>()
                .RetryForever(exception =>  
                {
                    // log.Warning("Failed, retrying....");
                });
    
       p.ExecuteAsync(async() => await DownloadAsync());
        
