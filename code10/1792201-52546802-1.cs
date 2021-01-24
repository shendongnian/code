    public MainPage()
    {
        InitializeComponent();
        TaskTest();
    }
    private async void TaskTest()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
               label.Text = await client.DownloadStringTaskAsync("https://www.example.com/return.php");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
