    public MainWindow()
    {
        InitializeComponent();
        // Very important to get the binding working.
        this.DataContext = this;
    }
    // The property to bind to, you should choose a better type than object.
    public IList<object> MyList
    {
        get { return (IList<object>)GetValue(MyListProperty); }
        set { SetValue(MyListProperty, value); }
    }
    public static readonly DependencyProperty MyListProperty =
            DependencyProperty.Register("MyList", typeof(IList<object>), typeof(MainWindow), new PropertyMetadata(null));
