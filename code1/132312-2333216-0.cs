    void UpdateProgress(object sender, DownloadProgressChangedEventArgs e) {
        setProgress(e.ProgressPercentage);
        setText(e.ProgressPercentage.ToString() + "%");
    }
    private void setProgress(int progress){
        if (dwnProgress.InvokeRequired) {
            dwnProgress.Invoke(new Action<int>(setProgress), progress);
            return;
        }
        dwnProgress.Value = progress;
    }
    
    private void setText(string text) {
       if (dwnprcnt.InvokeRequired) {
           dwnprcnt.Invoke(new Action<string>(setText), text);
           return;
       }
       dwnprcnt.Text = text;
    }
