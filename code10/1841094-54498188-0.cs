    private void button4_Click(object sender, EventArgs e)
    {
        using (var client = new WebClient())
        {
            MessageBox.Show("File will start downloading");
            var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SOMEFILENAME.exe");
            client.DownloadFileAsync(new Uri("GOOGLE DRIVE LINK"), path);
            MessageBox.Show("File has been downloaded!");
            System.Diagnostics.Process.Start(path);
        }
    }
