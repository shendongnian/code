    BackgroundWorker bwButtonWorker;
    public Window1() {
        InitializeComponent();
        bwButtonWorker = new BackgroundWorker();
        bwButtonWorker.DoWork += (sender, args) => {
            // do your lengthy stuff here -- this happens in a separate thread
            Thread.Sleep(2000);
        }
        bwButtonWorker.RunWorkerCompleted += (sender, args) => {
            // this happens in the UI thread, so you can modify your UI elements here
            Message.Text = "Button is ready to click again.";
            Button_Refresh.IsEnabled = true;
        }
    }
    
    private void Button_Refresh_Click(object sender, RoutedEventArgs e)
    {
        Message.Text = "working...";
        Button_Refresh.IsEnabled = false;
        bwButtonWorker.RunWorkerAsync();
    }
