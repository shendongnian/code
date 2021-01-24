    private WebClient _web;
    
    private void button1_Click(object sender, EventArgs e)
    {
        UseWaitCursor = true;
        button1.Enabled = false;
    
        _web = new WebClient();
        _web.Encoding = System.Text.Encoding.UTF8;
        _web.DownloadStringCompleted += DownloadCompleted;
        _web.DownloadStringAsync("https://stackoverflow.com/");
    }
    
    private void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
    	textBox1.Text = e.Result;
        UseWaitCursor = false;
        button1.Enabled = true;
        _web.Dispose();
    }
