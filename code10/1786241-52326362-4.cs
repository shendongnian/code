    public void StartMonitoring(IProgress<Status> progress)
    {
        ...
        taskTimer.Elapsed += delegate
        {
            progress.Report(new Status(false,"Starting"));
            //call DeviceController here//
            //do stuff//
            //something went wrong//
            progress.Report(new Status(true,"Something went wrong"));
        };
        ...
    }
