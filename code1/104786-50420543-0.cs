    protected override void OnFormClosing(FormClosingEventArgs e) {
    
        this.Enabled = false;   // or this.Hide()
        e.Cancel = true;
        backgroundWorker1.CancelAsync();  
        while (backgroundWorker1.IsBusy) {
            Application.DoEvents();
        }
        e.cancel = false;
        base.OnFormClosing(e);
    }
