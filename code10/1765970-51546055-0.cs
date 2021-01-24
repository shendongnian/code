    private ImageSource_OutfitImage;
    public ImageSource OutfitImage
    {
        get { return _OutfitImageString; }
        set
        {
            _OutfitImageString = value;
            NotifyPropertyChanged(nameof(OutfitImage));
        }
    }
