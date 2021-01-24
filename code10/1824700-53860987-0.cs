    public MyUserControl()
    {
        this.InitializeComponent();
        this.Loaded += MyUserControl_Loaded;
        this.Unloaded += MyUserControl_Unloaded;                
    }
    
    private void MyUserControl_Loaded(object sender, RoutedEventArgs e)
    {
        Application.Current.Suspending += MyUserControl_Suspending;
    }
    
    private void MyUserControl_Unloaded(object sender, RoutedEventArgs e)
    {
        Application.Current.Suspending -= MyUserControl_Suspending;
    }
    
    private void MyUserControl_Suspending(object sender, SuspendingEventArgs e)
    {
        // your control's OnSuspending code here
    }
