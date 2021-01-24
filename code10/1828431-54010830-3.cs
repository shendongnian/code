    protected override void OnPaint(PaintEventArgs e)
    {
        PaintAsync(e);
        Debug.WriteLine("done painting");
    }
    private async Task PaintAsync(PaintEventArgs e)
    {
        Thread.Sleep(5000);
        base.OnPaint(e);
    }
