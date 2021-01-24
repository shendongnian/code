    private void CreateThumbnail()
    {
        Image thumbnailImage = new Image();
	
        thumbnailImage.Width = 130;
 
        BitmapImage bmpImage = new BitmapImage();
        bmpImage.BeginInit();
        bmpImage.UriSource = new Uri("Garden.jpg", UriKind.RelativeOrAbsolute); //your image path
        bmpImage.DecodePixelWidth = 120;
        bmpImage.DecodePixelHeight = 120;
        bmpImage.EndInit();
        // Set Source property of Image
        thumbnailImage.Source = bmpImage;
    }
