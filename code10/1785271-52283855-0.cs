    BitmapImage _displayedImage;
    public BitmapImage DisplayedImage 
    {
        get { return displayedImage; }
        set { displayedImage = value; NotifyPropertyChanged(nameof(DisplayedImage)); }
    }
