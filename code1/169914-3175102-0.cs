    private void panel1_Paint(object sender, PaintEventArgs e)     {
        ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, 
        Color.DarkBlue, ButtonBorderStyle.Solid);
    }
    private void panel1_Resize(object sender, EventArgs e)
    {
        Invalidate();
    }
