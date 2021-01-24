    private async void PickAFileButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");
        StorageFile file = await openPicker.PickSingleFileAsync();
        if (file != null)
        {   await file.CopyAsync( ApplicationData.Current.LocalFolder );
            // Application now has read/write access to the picked file
            String a = "ms-appdata:///local/" + file.Name;
            theItem.Source = new BitmapImage(new Uri(a));
        }
        else
        {
            theImage.Text = "Operation cancelled.";
        }
    }
  
