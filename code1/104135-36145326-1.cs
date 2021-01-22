    public static readonly DependencyProperty MyImageSourceProperty =
            DependencyProperty.Register("MyImageSource", 
                 typeof(string),typeof(UserControl1),
    new FrameworkPropertyMetadata(OnImageSourcePathChanged));
        public string MyImageSource
        {
            get { return (BitmapImage)GetValue(MyImageSourceProperty); }
            set { SetValue(MyImageSourceProperty, value); }
        }
     private static void OnImageSourcePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UserControl1)d).MyImageSource.Source = new BitmapImage(new Uri(e.NewValue as string));
        }
