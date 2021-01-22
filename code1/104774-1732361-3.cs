    private bool closePending;
    protected override void OnFormClosing(FormClosingEventArgs e) {
        if (backgroundWorker1.IsBusy) {
            closePending = true;
            backgroundWorker1.CancelAsync();
            e.Cancel = true;
            this.Enabled = false;   // or this.Hide()
            return;
        }
        base.OnFormClosing(e);
    }
    
    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        if (closePending) this.Close();
        closePending = false;
        // etc...
    }
