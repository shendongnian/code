    protected override void OnPaint(PaintEventArgs e)
    {
        if (!_DoubleBufferedGraphics.Initialized)
        {
            _DoubleBufferedGraphics.Initialize(Width, Height);
        }
        _DoubleBufferedGraphics.Graphics.DrawLine(...);
        _DoubleBufferedGraphics.Render(e.Graphics);
    }
