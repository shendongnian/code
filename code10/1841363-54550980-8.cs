    public RelayCommand<RoutedEventArgs> ButtonCommand { get; }
    ButtonCommand = new RelayCommand<RoutedEventArgs>( x => Foo(x) );
    private void Foo( RoutedEventArgs args)
    {
        string buttonName = ( ( System.Windows.FrameworkElement )args.Source ).Name;
        //Your switch statements..
    }
