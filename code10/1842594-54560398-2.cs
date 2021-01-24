    // We need preserve updating task to close it properly
    private Task _updatingTask;
    private async void FormLoad(object sender, EventArgs e)
    {
         _runUpdating = true;
         _intervalMilliseconds = 1000;
         _updatingTask = StartUpdatingChart();
    }
    private async void FormClosed(object sender, EventArgs e)
    {
         _runUpdating = false;
         // await for task to be completed
         await _updatingTask;
    }
