            // . . .
            await SetImageAsync("image.jpg");
            // . . . 
        }
        private async Task SetImageAsync(string imageName)
        {
            // Load the imageName file from the PicturesLibrary
            // This requires the app have the picturesLibrary capability
            var imageFile = await KnownFolders.PicturesLibrary.GetFileAsync(imageName);
            using (var imageStream = await imageFile.OpenReadAsync())
            {
                var image = new BitmapImage();
                image.DecodePixelWidth = 100;
                // Load the image from the file stream
                await image.SetSourceAsync(imageStream);
                this.img.Source = image;
            }
        }
