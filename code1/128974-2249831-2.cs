    public static void PlayPlaylist()
    {
        itapp = new iTunesApp();
        itapp.OnPlayerStopEvent += new _IiTunesEvents_OnPlayerStopEventEventHandler(itapp_OnPlayerStopEvent);
    
        lastPlaylistID = itapp.LibraryPlaylist.playlistID;
        Debug.WriteLine("Last playlist:");
        Debug.WriteLine(lastPlaylistID);
    
        itapp.Play();
    
        while (true)
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
