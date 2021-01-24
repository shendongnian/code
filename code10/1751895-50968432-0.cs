    public
    MainWindow()
    {
        InitializeComponent();
        var cts = new CancellationTokenSource();
        var task = CheckToClose(cts.Token);
        Closing += delegate { cts.Cancel(); };
    }
    async
    Task CheckToClose(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            try { await Task.Delay(TimeSpan.FromSeconds(60), ct); } catch (TaskCanceledException) { return; }
            var keepRunning = await ShouldKeepRunning(ct);
            if (!keepRunning)
            {
                Close();
                return;
            }
        }
    }
    Task<bool> ShouldKeepRunning(CancellationToken ct) =>
        // it's important here to take a thread pool task here so that working with the DB
        // doesn't block the UI
        Task.Run<bool>(
            delegate
            {
                // here you ask the DB whether you keep running
                // if working with DB is potentially too slow,
                // then take the CancellationToken into account
            });
