    public ImageSource Icon
    {
        get { return (ImageSource)this.GetValue(IconProperty); }
        set { this.SetValue(IconProperty, value); }
    }
    
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(NavigationButton), new FrameworkPropertyMetadata(OnIconChanged));
    
    private static void OnIconChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        //do whatever you want here - the first parameter is your DependencyObject
    }
