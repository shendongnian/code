    class CanvaNetwork : Canvas
    {
      public CanvaNetwork ( ) { }
  
      public static readonly DependencyProperty NewMouseOverProperty
                               = DependencyProperty.Register ( "NewMouseOver",
                                                               typeof (bool),
                                                               typeof (CanvaNetwork),
                                                               new PropertyMetadata (false, OnNewMouseOverChanged)) ;
  
      public bool NewMouseOver
      {
        get { return (bool)GetValue (NewMouseOverProperty); }
        set { SetValue (NewMouseOverProperty, value); }
      }
  
      public static void OnNewMouseOverChanged ( DependencyObject d, DependencyPropertyChangedEventArgs e )
      {
      }
    }
