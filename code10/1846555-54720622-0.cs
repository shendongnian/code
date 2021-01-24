    var retryPolicy = Policy
        .HandleResult<string>(s => s.Contains("whatever text triggers retry")) // or whatever more complicated predicate you want
        .Retry...Async(...); // whatever flavour of retry overload you want
    private async Task DownloadAsync()
    {
       using (var wc = new GZipWebClient())
       {
          // this html sometimes contain <title> with error message
          html = await retryPolicy.ExecuteAsync(() => wc.DownloadStringTaskAsync(url));
       }
    }
