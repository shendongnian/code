     public static void DownloadFile(DriveService service, Google.Apis.Drive.v2.Data.File file, string saveTo)
            {
    
                var request = service.Files.Get(file.Id);
                var stream = new System.IO.MemoryStream();
    
                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                SaveStream(stream, saveTo + @"/" + file.Title);
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                if (file.ExportLinks.Any())
                                    SaveStream(new HttpClient().GetStreamAsync(file.ExportLinks.FirstOrDefault().Value).Result, saveTo + @"/" + file.Title);
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
    
                try
                {
                    request.Download(stream);
                }
                catch (Exception ex)
    
                {
                    Console.Write("Error: " + ex.Message);
                }
    
            }
