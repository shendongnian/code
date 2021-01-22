      public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(IList), typeof(YourControl),
                newFrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.AffectsArrange,new PropertyChangedCallback(OnIsChanged)));
    
     private static void OnIsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                YourControl c = (YourControl)d;
                c.OnPropertyChanged("ItemsSource");
            }
    
     public IList ItemsSource
            {
                get
                {
                    return (IList)GetValue(ItemsSourceProperty);
                }
                set
                {
                    SetValue(ItemsSourceProperty, value);
                }
            } 
