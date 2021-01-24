    List<Episode> downloading = new List<Episode>();
    var newEpisode = new Episode() { Title = epInfo[0], Progress = "0%" };	
		
    downloading.Add(newEpisode);
    lvPodDownloads.Items.Add(newEpisode);
    
    using (WebClient client = new WebClient())
    {
    	client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => ProgressChanged(sender, e, newEpisode));
    }
