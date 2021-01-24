    public MainWindow()
    {
        this.DataContext = this;
        InitializeComponent();
        Loaded += async (s, e) =>
        {
            Debug.WriteLine("before Task<int> taskS = TaskOfTResult_MethodSync(10000);");
            int i = await TaskOfTResult_MethodSync(10000);
            Debug.WriteLine($"i = {i}");
            Debug.WriteLine($"");
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Debug.WriteLine("before TestTask3(1000, token);");
            await TestTask3(1000, token);
            Debug.WriteLine("after TestTask3(1000, token);");
            await Task.Delay(2000);
            Debug.WriteLine("after sleep on main TestTask3(1000, token);");
            source.Cancel();
            Debug.WriteLine("done Main");
        };
    }
    public async Task TestTask3(int delay, CancellationToken ct)
    {
        Debug.WriteLine($"TestTask3");
        await Task.Run(async () =>
        {
            // … do compute-bound work here 
            for (int j = 101; j <= 120; j++)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(delay);
                ans = j;
                Answer = j;
            }
        });
        Debug.WriteLine($"TestTask3   {ans}");
        Answer = ans;
    }
