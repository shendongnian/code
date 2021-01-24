    public RelayCommand<RoutedEventArgs> ButtonCommand { get; }
    ButtonCommand = new RelayCommand<RoutedEventArgs>( x => Test(x) );
    private void Test( RoutedEventArgs args)
    {
        string buttonName = ( ( System.Windows.FrameworkElement )args.Source ).Name;
        //Your switch statements..
    }
