    public System.Drawing.Graphics Graphics
    {
        get
        {
            if (graphics == null && dc != IntPtr.Zero)
            {
                oldPal = Control.SetUpPalette(dc, false /*force*/, false /*realize*/);
                graphics = Graphics.FromHdcInternal(dc);
                graphics.PageUnit = GraphicsUnit.Pixel;
                savedGraphicsState = graphics.Save(); // See ResetGraphics() below
            }
            return graphics;
        }
    }
