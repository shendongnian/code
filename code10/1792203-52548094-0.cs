    public MainPage() {
        InitializeComponent();
        Downloading += OnDownloading; //subscribe to event
        Downloading(this, EventArgs.Empty); //raise event to be handled
    }
    private event EventHandler Downloading = delegate { };
    private async void OnDownloading(object sender, EventArgs args) {
         //Downloading -= OnDownloading; //unsubscribe (optional)
        label.Text = await TaskTest(); //this works
    }
    
    private async Task<string> TaskTest() {
        try {
            using (WebClient client = new WebClient()) {
               return await client.DownloadStringTaskAsync("https://www.example.com/return.php");
            }
        } catch (Exception) {
            throw;
        }
    }
