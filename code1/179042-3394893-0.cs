     public static readonly DependencyProperty SelectedColorProperty
       = DependencyProperty.Register("SelectedColor", typeof(SolidBrushColor ), 
                                                    typeof(<yourviewmodel>),
                                                    new UIPropertyMetadata(GetDefaultColor()));
      Where GetDefaultColor() is a static method in your ViewModel, 
      which will return the required color from your ObservableCollection .
    
