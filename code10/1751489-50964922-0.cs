    public MainForm()
    {
        InitializeComponent();
        cts = new CancellationTokenSource();
        Load += MainForm_Load;
        FormClosing += MainForm_FormClosing;
    }
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        cts.Cancel();
    }
    private void MainForm_Load(object sender, EventArgs e)
    {        
        CancellationToken ct = cts.Token;
        Action action = () => { lblTime.Text = DateTime.Now.ToLongTimeString(); };
        var task = Task.Factory.StartNew(async () => {
            ct.ThrowIfCancellationRequested();
            while (true)
            {
                Invoke(action);
                await Task.Delay(100);
            }
        }, ct);
    }
