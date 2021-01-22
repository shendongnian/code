    private void StartBackgroundWork() {
        if (Application.RenderWithVisualStyles)
            progressBar.Style = ProgressBarStyle.Marquee;
        else {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            timer.Enabled = true;
        }
        backgroundWorker.RunWorkerAsync();
    }
    
    private void timer_Tick(object sender, EventArgs e) {
        progressBar.Value += 5;
        if (progressBar.Value > 120)
            progressBar.Value = 0;
    }
