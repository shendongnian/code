    public ImageSource Image
    {
        get { return BitmapFrame.Create(
                  ImageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad); }
    }
