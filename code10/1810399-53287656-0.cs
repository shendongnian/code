    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        this.pbStatus.Value = 0;
        //Setup the progress reporting
        var progress = new Progress<int>(i =>
        {
            this.lblOutput.Text = i.ToString();
            this.pbStatus.Value = i;
        });
        Task.Run(() => StartProcess(100, progress));
        //Show message box to demonstrate that StartProcess()
        //is running asynchronously
        MessageBox.Show("Called after async process started.");
    }
    // Called Asynchronously
    private void StartProcess(int max, IProgress<int> progress)
    {
        for (int i = 0; i <= max; i++)
        {
            //Do some work
            Thread.Sleep(10);
            //Report your progress
            progress.Report(i);
        }
    }
