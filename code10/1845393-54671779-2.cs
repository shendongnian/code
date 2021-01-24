    var driver = Periphrials.InitializeArduinoDriver();
    StillMonitor = new BackgroundWorker();
    StillMonitor.WorkerSupportsCancellation = true;
    StillMonitor.WorkerReportsProgress = true;
    StillMonitor.DoWork += new DoWorkEventHandler((state, args) =>
    {
        do
        {
            if (StillMonitor.CancellationPending)
            { 
                break;
            }
            StillMonitor.ReportProgress(0); //Invokes the ProgressChanged Event on the thread the backgroundworker was created on.
        } while (true);
    });
    StillMonitor.ProgressChanged += (sender, e) => {
         (driver.Send(new DigitalReadRequest(properties.StillLowSwitch)).PinValue.ToString() == "Low")
    }
