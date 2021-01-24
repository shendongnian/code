    public MyDialog()
    {
        this.InitializeComponent();
        this.Loaded += MyDialog_Loaded;
    
        this.Closing += ContentDialog_Closing;
        //this.KeyDown += onE_KeyDown;
        this.KeyUp += MyDialog_KeyUp;
    }
    
    private void MyDialog_KeyUp(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Escape)
        {
            //btnCancel_Click(sender, e); 
            btnCancel_Click(this, new RoutedEventArgs());
        }
    }
    
    void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
    {
        //args.Cancel = syncInProcess;
        // btnCancel_Click(this, new RoutedEventArgs());
        if (args.Result == ContentDialogResult.None)
        {
            args.Cancel = true;
        }
    }
