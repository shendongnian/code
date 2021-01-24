    using (var wc = new System.Net.WebClient())
    {
       wc.DownloadFile(remoteUri, localFilename);
    }
   
