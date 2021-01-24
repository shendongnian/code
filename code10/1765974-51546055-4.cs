    private ImageSource _OutfitImage;
    public ImageSource OutfitImage
    {
        get { return _OutfitImage; }
        set
        {
            _OutfitImage = value;
            NotifyPropertyChanged(nameof(OutfitImage));
        }
    }
