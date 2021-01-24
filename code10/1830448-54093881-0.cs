    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        dynamic data = e.Argument;
        string fPath = data["file"];
        byte[] buffer;
        int bytesRead;
        long size;
        long totalBytesRead = 0;
        using (Stream file = File.OpenRead(fPath))
        {
            size = file.Length;
            progressBar1.Visible = true;
            HashAlgorithm hasher = MD5.Create();
            do
            {
                buffer = new byte[4096];
                bytesRead = file.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;
                hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                backgroundWorker1.ReportProgress((int)((double)totalBytesRead / size * 100));
            }
            while ( bytesRead != 0) ;
            hasher.TransformFinalBlock(buffer, 0, 0);
            e.Result = MakeHashString(hasher.Hash);
            
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
      private void md5HashBtn_Click(object sender, EventArgs e)
            {
                if (MD5TextBox.Text.Length > 0)
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("algo", "MD5");
                    param.Add("file", MD5TextBox.Text);
                    backgroundWorker1.RunWorkerAsync(param);
                }
            }
