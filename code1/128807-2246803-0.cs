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
            if (ImageFullPath1Changed != null && value != _backingField)
                ImageFullPath1Changed(this, new EventArgs(/*whatever*/);
        }
    }                        
