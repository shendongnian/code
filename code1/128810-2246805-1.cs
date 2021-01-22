    public event EventHandler ImageFullPath1Changed;
    private string _imageFullPath1 = string.Empty;
    public string ImageFullPath1 
    {
      get
      {
        return imageFullPath1 ;
      }
      set
      {
        if (_imageFullPath1 != value)
        { 
          _imageFullPath1 = value;
          EventHandler handler = ImageFullPathChanged;
          if (handler != null)
            handler(this, e);
        }
      }
    }
