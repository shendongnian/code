        private async Task<String> DownloadImage(string url, String fileName)
        {
            const String imagesSubdirectory = "DownloadedImages";
            var rootFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(imagesSubdirectory, CreationCollisionOption.OpenIfExists);
            var storageFile = await rootFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (HttpClient client = new HttpClient())
            {
                byte[] buffer = await client.GetByteArrayAsync(url);
                using (Stream stream = await storageFile.OpenStreamForWriteAsync())
                    stream.Write(buffer, 0, buffer.Length);
            }
            // Use this path to load image
            String newPath = String.Format("ms-appdata:///local/{0}/{1}", imagesSubdirectory, fileName);
            return newPath;
        }
        // Here is an example of how to use the new DownloadImage() method
        private async void Button_Download(object sender, RoutedEventArgs e)
        {
            var uniqueFileName = $@"{Guid.NewGuid()}.jpg";
            String newPath = await DownloadImage("https://images.unsplash.com/photo-1535159530326-d7bf54bfb24e?ixlib=rb-0.3.5&q=85&fm=jpg&crop=entropy&cs=srgb&ixid=eyJhcHBfaWQiOjM1NDkzfQ&s=6dbf8e03a25f469d0f845992e6b2eb9e",
                uniqueFileName);
            myImage.Source = new BitmapImage(new Uri(newPath));
        }
