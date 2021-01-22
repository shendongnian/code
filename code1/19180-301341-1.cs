    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        this.Capture = true;
    }
    protected override void OnCaptureChanged(EventArgs e)
    {
        if (!this.Capture)
        {
            if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
            {
                this.Close();
            }
            else
            {
                this.Capture = true;
            }
        }
        base.OnCaptureChanged(e);
    }
