    private ImageSource _loadingImage;
    public ImageSource LoadingImage
    {
        get => _loadingImage;
        set
        {
            _loadingImage = value;
            RaisePropertyChanged(nameof(LoadingImage));
        }
    }
