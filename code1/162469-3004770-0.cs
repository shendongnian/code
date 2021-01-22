    static void DownloadInParallel(string[] urls)
    {
       var tempFolder = Path.GetTempPath();
    
       var downloads = from url in urls
                       select Task.Factory.StartNew<string>(() =>{
                           using (var client = new WebClient())
                           {
                               var uri = new Uri(url);
                               string file = Path.Combine(tempFolder,uri.Segments.Last());
                               client.DownloadFile(uri, file);
                               return file;
                           }
                       },TaskCreationOptions.LongRunning|TaskCreationOptions.AttachedToParent)
                      .ContinueWith(t=>{
                           var filePath = t.Result;
                           File.Move(filePath, filePath + ".test");
                      },TaskContinuationOptions.ExecuteSynchronously);
        var results = downloads.ToArray();
        Task.WaitAll(results);
    }
