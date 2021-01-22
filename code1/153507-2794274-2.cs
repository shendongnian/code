    void DownloadProgress(object sender, DownloaderProgressArgs e) 
    {
        Action updateLabel = () => label2.Text = d.speedOutput.ToString();
        if (this.InvokeRequired) 
        {
            this.BeginInvoke(updateLabel);
        }
        else
        {
           updateLabel();
        }
    }
    
    void DownloadSpeed(object sender, DownloaderProgressArgs e) {
    
        Action updateSpeed = () => 
        {
            string speed = "";
            speed = (e.DownloadSpeed / 1024).ToString() + "kb/s";
            label3.Text = speed;
        };
    
        if (this.InvokeRequired)
        {
            this.BeginInvoke(updateSpeed);
        }
        else
        {
            updateSpeed();
        }
    }
