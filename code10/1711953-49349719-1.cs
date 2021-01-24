    private async void button1_Click(object sender, EventArgs e)
    {
        UseWaitCursor = true;
        button1.Enabled = false;
        using (WebClient web = new WebClient())
        {
            web.Encoding = System.Text.Encoding.UTF8;
            textBox1.Text = await web.DownloadStringTaskAsync("https://stackoverflow.com/");
        }
        UseWaitCursor = false;
        button1.Enabled = true;
    };
