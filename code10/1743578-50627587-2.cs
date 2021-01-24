    public Form1()
    {
        InitializeComponent();
        DoWorkAsynchronously();
    }
    private async Task DoWorkAsynchronously()
    {
        await Task.Run(() =>
        {
            while (true)
            {
                if (CheckData())
                {
                    TurnSirenOn();
                    client.DownloadString("**link to .php file to reset the .txt file**");
                    Thread.Sleep(5000);
                    TurnSirenOff();
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        });
    }
