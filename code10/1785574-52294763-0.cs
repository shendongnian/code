    public async System.Threading.Tasks.Task OpenMultipleAsync()
    {
        var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
        filePicker.FileTypeFilter.Add(".mp3");
        filePicker.FileTypeFilter.Add(".mp4");
        filePicker.FileTypeFilter.Add(".ogg");
        filePicker.FileTypeFilter.Add(".wav");
        filePicker.FileTypeFilter.Add(".wma");
        filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
        _mediaPlaybackList = new MediaPlaybackList();
        var files = await filePicker.PickMultipleFilesAsync();
        foreach (var file in files)
        {
            var mediaPlaybackItem = new MediaPlaybackItem(MediaSource.CreateFromStorageFile(file));
            _mediaPlaybackList.Items.Add(mediaPlaybackItem);
        }
        _mediaPlayer = new MediaPlayer();
        _mediaPlayer.Source = _mediaPlaybackList;
        mediaPlayerElement.SetMediaPlayer(_mediaPlayer);
    }
