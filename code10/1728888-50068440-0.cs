    public BitmapImage **ImageSource**
    {
        get
        {
            return imageSource;
        }
        set
        {
            imageSource = value;
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("**MessagePerSec")**;
        }
    }
