    public BitmapImage DisplayedHighPerformanceImage
    {
        get { return kMMHP; }
        set { kMMHP = value; NotifyPropertyChanged(nameof(DisplayedHighPerformanceImage)); }
    }
    DisplayedHighPerformanceImage = method1();
