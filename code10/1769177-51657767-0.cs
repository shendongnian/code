    HackTheTrack(scrollViewer.FindChildren<Track>().First());
    HackTheTrack(scrollViewer.FindChildren<Track>().Skip(1).Single()); // second track
    void HackTheTrack(Track track)
    {
        track.Visibility = Visibility.Visible;
        track.IsVisibleChanged += (s, ee) =>
        {
            if (track.Visibility != Visibility.Visible)
                track.Visibility = Visibility.Visible;
        };
    }
