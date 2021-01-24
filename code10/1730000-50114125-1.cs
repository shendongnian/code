    public MainWindow()
    {
        InitializeComponent();
        var cts = new CancellationTokenSource();
        Unloaded += delegate { cts.Cancel(); };
        ProcessData(cts.Token);
    }
    async void ProcessData(CancellationToken ct)
    {
        try
        {
            while (true)
            {
                ct.ThrowIfCancellationRequested();
                try
                {
                    var dataItem = await Task.Run(() => DataManagement.RequestData());
                    ProcessData(dataItem);
                }
                catch(Exception_Thrown_By_RequestData e)
                {
                    // decide what do - either break the loop or continue if
                    // this is not a heavy faiulre
                }
                await Task.Delay(DelayTime, ct);
            }
        }
        catch (TaskCanceledException) { }
        catch (OperationCanceledException) { }
    }
