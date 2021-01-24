    // this method contains async IO code aswell as CPU bound code
    // that has been offloaded to another thread
    public async Task ProcessAsync()
    {
       using (var zip = await downloader.DownloadAsZipArchive(downloadUrl))
       {
          // I would use Task.Run until it proves to be a performance bottleneck
          await Task.Run(() => ExtractZip(zip));
       }
    }
