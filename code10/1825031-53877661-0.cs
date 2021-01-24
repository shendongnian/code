    public void Run()
    {
        var runningForm = new RunningForm();
        runningForm.Loaded += async delegate 
        {
            runningForm.ShowRunning();
            var progressFormTask = runningForm.ShowDialogAsync();
            var data = await LoadDataAsync();
            runningForm.Close();
            await progressFormTask;
            MessageBox.Show(data.ToString());
        };
        System.Windows.Forms.Application.Run(runningForm);
    }
