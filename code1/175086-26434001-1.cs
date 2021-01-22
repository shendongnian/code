    public static void OnLoadedOnce(
        this UserControl control,
        RoutedEventHandler onLoaded)
    {
        if (control == null || onLoaded == null)
        {
            throw new ArgumentNullException();
        }
        RoutedEventHandler wrappedOnLoaded = null;
        wrappedOnLoaded = delegate(object sender, RoutedEventArgs e)
        {
            control.Loaded -= wrappedOnLoaded;
            onLoaded(sender, e);
        };
        control.Loaded += wrappedOnLoaded;
    }
    ...
    class MyControl : UserControl
    {
        public MyControl()
        { 
            InitializeComponent();
            this.OnLoadedOnce(this.OnControlLoaded /* or delegate {...} */);
        }
        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
