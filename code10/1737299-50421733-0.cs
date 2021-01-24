    async private Task<List<BitmapImage>> GetThumbnails(StorageFolder folder)
    {
        List<BitmapImage> BitmapImageList = new List<BitmapImage>();
        var files = await folder.GetFilesAsync();
        foreach (var file in files)
        {
            var thumb = await file.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.PicturesView);
            var bitmap = new BitmapImage();
            bitmap.SetSource(thumb);
            BitmapImageList.Add(bitmap);
        }
        return BitmapImageList;
    }
