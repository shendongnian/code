    public static async Task DoStuffAsync(Content[] contents, string siteurl, string src, string target)
    {
       var throttle = new SemaphoreSlim(10, 10);
    
       // local method
       async Task<(Content, SomeResponse)> PostAsyncWrapper(Content content)
       {
          await throttle.WaitAsync();
          try
          {
             // return a content and result pair
             return (content, await PostAsync(content, siteurl, src, target));
          }
          finally
          {
             throttle.Release();
          }   
       }
    
       var results = await Task.WhenAll(contents.Select(PostAsyncWrapper));
    
       // do stuff with your results pairs here
    }
