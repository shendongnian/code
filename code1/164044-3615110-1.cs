    public LoadVideoFromURL(string url)
    {
    	var uri = new Uri(url);
    
        //Request the video
        var videoDownloader = new WebClient();
        videoDownloader.OpenReadCompleted += new OpenReadCompletedEventHandler( 
                     (s, args) => myMediaElement.SetSource(args.Result));
        videoDownloader.OpenReadAsync(uri);
    }
