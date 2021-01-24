        //STORAGE FILE TO SHAPE
        public static async Task<Shape> StorageFileToShape(Shape TargetShape, StorageFile SourceStorageFile)
        {
            ImageBrush ShapeImageBrush = new ImageBrush();
            //Adding this line in my code problem was solved.
            ShapeImageBrush.Stretch = Stretch.UniformToFill;
            //
            using (var BitmapImageFileStream = await SourceStorageFile.OpenAsync(FileAccessMode.Read))
            {
                ShapeImageBrush.ImageSource = await StorageFileToBitmapImage(SourceStorageFile);
                TargetShape.Fill = ShapeImageBrush;
            }
            return TargetShape;
        }
        //STORAGE FILE TO BITMAP IMAGE
        public static async Task<BitmapImage> StorageFileToBitmapImage(StorageFile SourceStorageFile)
        {
            BitmapImage TargetBitmapImage = new BitmapImage();
            TargetBitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            using (var BitmapImageFileStream = await SourceStorageFile.OpenAsync(FileAccessMode.Read))
            {
                await TargetBitmapImage.SetSourceAsync(BitmapImageFileStream);
            }
            return TargetBitmapImage;
        }
