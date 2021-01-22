    public event EventHandler ImageFullPath1Changed;
    public string ImageFullPath1
    {
        get
        {
            // insert getter logic
        }
        set
        {
            // insert setter logic       
            // EDIT -- this example is not thread safe -- do not use in production code
            if (ImageFullPath1Changed != null && value != _backingField)
                ImageFullPath1Changed(this, new EventArgs(/*whatever*/);
        }
    }                        
