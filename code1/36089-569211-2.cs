    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (TabRenderer.IsSupported && Application.RenderWithVisualStyles)
        {
            TabRenderer.DrawTabPage(pe.Graphics, this.ClientRectangle);
        }
        else
        {
            base.OnPaintBackground(pe);
            ControlPaint.DrawBorder3D(pe.Graphics, this.ClientRectangle, Border3DStyle.Raised);
        }
    }
