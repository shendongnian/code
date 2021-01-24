    public async void Image_Drop(object sender, DragEventArgs e)
    {
         if (e.DataView.Contains(StandardDataFormats.StorageItems))
         {
            List<StorageFile> received_images = new List<StorageFile>();
            var items = await e.DataView.GetStorageItemsAsync();
            var storageFile = items[0] as StorageFile;
            received_images.Add(storageFile);
         }
    }
    private void Image_drop_drag_over_ui(object sender, DragEventArgs e)
    {
         e.AcceptedOperation = DataPackageOperation.Copy;
         e.DragUIOverride.Caption = "Drop receipt";
         e.DragUIOverride.IsCaptionVisible = true; 
    }
