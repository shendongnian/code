    `/// <summary>
     /// Downloads list up updates or update
     /// </summary>
     /// <param Update Collection="uCollection"></param>
     public void Download(UpdateCollection uCollection)
     {
         //creates new Downloader 
         UpdateDownloader uDownloader = new UpdateDownloader();
         //Sets Downloader updates
         uDownloader.Updates = uCollection;
         //Downloads the updates
         uDownloader.Download();
     }`
