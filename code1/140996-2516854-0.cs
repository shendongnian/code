    MediaElement musicPlayer = new MediaElement();
    musicPlayer.MediaOpened += (s, args) =>
    {
        var player = (MediaElement)s;
        if (player.CanSeek)
            player.Position =  new TimeSpan(0, 0, 30);   
    }                     
    musicPlayer.Source = new Uri(strMediaFileURL, UriKind.RelativeOrAbsolute);
    LayoutRoot.Children.Add(musicPlayer);
