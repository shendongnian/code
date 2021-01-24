    public ImageSource Background
    {
        get
        {
            if (BackgroundFile != null)
            {
                try
                {
                    return new BitmapImage(new Uri(BackgroundFile));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }
