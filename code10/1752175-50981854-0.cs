        private async Task SetSourceAsync(Image image, Uri uri)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(await file.OpenAsync(FileAccessMode.Read));
                image.Source = bitmapImage;
            });
        }
