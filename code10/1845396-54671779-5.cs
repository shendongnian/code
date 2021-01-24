    using System.Windows.Threading; //WindowsBase.dll
    //...
    var driver = Periphrials.InitializeArduinoDriver();
    Dispatcher driverDispatcher = Dispatcher.CurrentDispatcher; //Gets the Dispatcher for the current Thread (or creates it)
    StillMonitor = new BackgroundWorker();
    StillMonitor.WorkerSupportsCancellation = true;
    StillMonitor.DoWork += new DoWorkEventHandler((state, args) =>
    {
        do
        {
            if (StillMonitor.CancellationPending)
            { 
                break;
            }
            driverDispatcher.Invoke(new Action(() => { //Invoke and block the Dispatcher
                (driver.Send(new DigitalReadRequest(properties.StillLowSwitch)).PinValue.ToString() == "Low")  
            }));    
        } while (true);
    });
