    public ImageSource ImageSource
    {
        get { return BitmapFrame.Create(
                  ImageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad); }
    }
