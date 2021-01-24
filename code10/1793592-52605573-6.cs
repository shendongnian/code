    public ImageSource Image
    {
        get { return BitmapFrame.Create(
                  new Uri(ImageUri), BitmapCreateOptions.None, BitmapCacheOption.OnLoad); }
    }
