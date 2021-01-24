    System.Timers.Timer timer; //Declare it as a class member, not a local field, so it won't get GC'ed. 
    public MainWindow()
    {
        InitializeComponent();
        timer = new System.Timers.Timer(1000);
        timer.AutoReset = false; //the Elapsed event should be one-shot
        timer.Elapsed += (o, e) =>
        {
            //Since this is running on a background thread you need to marshal it back to the UI thread.
            Dispatcher.BeginInvoke(new Action(() => {
                innerGrid.Width = root.ActualWidth;
                innerGrid.Height = root.ActualHeight;
            }));
        };
        this.SizeChanged += (o, e) =>
        {
            //restart the time if user is still manipulating the window             
            timer.Stop(); 
            timer.Start();
        };
    }
