    public List<Tuple<int, int>> MorseCodeSequence;
    CancellationTokenSource source;
    CancellationToken token;
    private void button1_Click(object sender, EventArgs e)
    {
        if (source != null)
        {
            source.Cancel();
            source.Dispose();
            source = null;
            return;
        }
        source = new CancellationTokenSource();
        token = source.Token;
        MorseCodeSequence = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(1200, 200),
            new Tuple<int, int>(400, 200),
            new Tuple<int, int>(1200, 200),
            new Tuple<int, int>(400, 2000)
        };
        Task.Run(()=> MorseSequence(MorseCodeSequence, this.btnMorse, token));
    }
    public async Task MorseSequence(List<Tuple<int, int>> MorseSequence, Control MorseCodeOutputObject, CancellationToken token)
    {
        while (true)
        {
            foreach (Tuple<int, int> MorseTiming in MorseSequence)
            {
                MorseCodeOutputObject.BeginInvoke(new MethodInvoker(() =>
                    { MorseCodeOutputObject.BackColor = Color.Cyan; }));
                await Task.Delay(MorseTiming.Item1);
                MorseCodeOutputObject.BeginInvoke(new MethodInvoker(() =>
                    { MorseCodeOutputObject.BackColor = Color.Gray; }));
                await Task.Delay(MorseTiming.Item2);
            }
            if (token.IsCancellationRequested) return;
        };
    }
