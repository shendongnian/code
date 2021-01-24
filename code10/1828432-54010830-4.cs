    protected override async void OnPaint(PaintEventArgs e)
    {
        await PaintAsync(e);
        Debug.WriteLine("done painting");
    }
    private async Task PaintAsync(PaintEventArgs e)
    {
        Thread.Sleep(5000);
        base.OnPaint(e);
    }
