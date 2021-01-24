    public async void Funcion()
    {
        var picker = new Windows.Storage.Pickers.FolderPicker()
        {
            ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
            SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads,
            SettingsIdentifier = "Setting"
        };
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".png");
    
        Windows.Storage.StorageFolder folder = await picker.PickSingleFolderAsync();
        StorageApplicationPermissions.FutureAccessList.AddOrReplace(folder.Name, folder);
        ObservableCollection<BitmapImage> sourceImage = new ObservableCollection<BitmapImage>();
        IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
        if (files != null)
        {
            foreach (var file in files)
            {
                var thumbnail = await file.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.PicturesView);
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(thumbnail);
                sourceImage.Add(bitmap);
            }
        }
        //String path = folder.Path; //getting the path of a folder selected by the user
        //String path2 = Directory.GetCurrentDirectory() + @"\Images"; //This one works
    
        FVtest.ItemsSource = sourceImage;
    }
