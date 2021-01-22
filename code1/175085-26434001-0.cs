    public static void OnLoadOnce(
        this UserControl control,
        RoutedEventHandler onLoad)
    {
        if (control == null || onLoad == null)
        {
            throw new ArgumentNullException();
        }
        RoutedEventHandler wrappedOnLoad = null;
        wrappedOnLoad = delegate(object sender, RoutedEventArgs e)
        {
            control.Loaded -= wrappedOnLoad;
            onLoad(sender, e);
        };
    }
    ...
    class MyControl : UserControl
    {
        public MyControl()
        { 
            InitializeComponent();
            this.OnLoadOnce(this.OnControlLoad /* or delegate {...} */);
        }
        private void OnControlLoad(object sender, RoutedEventArgs e)
        {
        }
    }
