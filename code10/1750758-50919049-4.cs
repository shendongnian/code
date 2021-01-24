    private async void pickFileButton_Click(object sender, RoutedEventArgs e)
    {
        // Schedule the work here on the same thread as the VideoPlayer window,
        //    so that it has access to the file and MediaSource to play.
        await this.VideoPlayerView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
        {
            // Create and open the file picker
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".mkv");
            openPicker.FileTypeFilter.Add(".avi");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                MediaSource sourceFromFile = MediaSource.CreateFromStorageFile(file);
                // Raise the event declaring that a video was selected.
                this.RaiseVideoSelectedEvent(sourceFromFile);
             }
        });
    }
