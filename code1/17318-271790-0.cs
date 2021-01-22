    public Form1()
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            client.DownloadDataAsync(new Uri("http://www.google.com"));
        }
        InitializeComponent();
    }
    void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        textBox1.Text += "A";
    }
