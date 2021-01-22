    static void DownloadInParallel2(string[] urls)
    {
        var tempFolder = Path.GetTempPath();
        var downloads = from url in urls
             let uri=new Uri(url)
             let filePath=Path.Combine(tempFolder,uri.Segments.Last())
             select new WebClient().DownloadDataTask(uri)                                                        
             .ContinueWith(t=>{
                var img = Image.FromStream(new MemoryStream(t.Result));
                img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                img.Save(filePath);
             },TaskContinuationOptions.ExecuteSynchronously);
            
        var results = downloads.ToArray();
        Task.WaitAll(results);
    }
