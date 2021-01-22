    public sealed class HtmlAsyncCache : AsyncCache<Uri, string>
    {
        public HtmlAsyncCache() : 
            base(uri => new WebClient().DownloadStringTask(uri)) { }
    }
    ...
    HtmlAsyncCache cache = new HtmlAsyncCache();
    var page1 = cache.GetValue(new Uri(“http://msdn.microsoft.com/pfxteam”));
    var page2 = cache.GetValue(new Uri(“http://msdn.com/concurrency”));
    var page3 = cache.GetValue(new Uri(“http://www.microsoft.com”)); 
    
    Task.Factory.ContinueWhenAll(
        new [] { page1, page2, page3 }, completedPages =>
    {
        … // use the downloaded pages here
    });
