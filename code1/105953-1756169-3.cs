    public static readonly DependencyProperty IsEverythingLoadedProperty =
        DependencyProperty.Register("IsEverythingLoaded", typeof(Boolean),
                                     typeof(YourCodeBehindClass), new PropertyMetadata(false));
 
    public Boolean IsEverythingLoaded {
        get { return (Boolean)this.GetValue(IsEverythingLoadedProperty); }
        set { this.SetValue(IsEverythingLoadedProperty, value); } 
    }
