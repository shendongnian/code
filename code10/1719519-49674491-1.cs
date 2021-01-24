    Image _originalImage;
    public Image OriginalImage
    {
        get => _originalImage;
        set
        {
             _originalImage = value;
             OnPropertyChanged();
        }
    }
