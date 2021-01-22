    if (Application.RenderWithVisualStyles)
    {
        TabRenderer.DrawTabPage(e.Graphics, this.ClientRectangle);
    }
    else
    {
        base.OnPaintBackground(e);
        ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Raised);
    }
