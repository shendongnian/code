    public string ScreenStatusBarText
    {
        get { return screenStatusBarText; }
        set
        {
            screenStatusBarText = value;
            OnPropertyChanged(nameof(ScreenStatusBarText));
        }
    }
