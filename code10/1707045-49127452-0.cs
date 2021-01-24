    public MainWindow()
    {
        InitializeComponent();
        btn.Click += Wrap(Button_Click);
    }
    public RoutedEventHandler Wrap(RoutedEventHandler handler)
    {
        return (sender, e) =>
        {
            try
            {
                this.IsEnabled = true;
                handler(sender, e);
            }
            finally
            {
                this.IsEnabled = false;
            }
        };
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Code
    }
