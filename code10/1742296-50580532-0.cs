    private async Task<BitmapImage> GetThumbnail(StorageFile file)
    {
        if (file != null)
        {
            StorageItemThumbnail thumb = await file.GetScaledImageAsThumbnailAsync(ThumbnailMode.VideosView);
            if (thumb != null)
            {
                BitmapImage img = new BitmapImage();
                await img.SetSourceAsync(thumb);
                return img;
            }
        }
        return null;
    }
