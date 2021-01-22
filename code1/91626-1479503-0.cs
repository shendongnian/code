    public Panel CreateFloatingPanel(Panel originalPanel)
    {
        Bitmap bmp = new Bitmap(originalPanel.Width, 
            originalPanel.Height);
        Rectangle rect = new Rectangle(0, 0, 
            bmp.Width, bmp.Height);
        originalPanel.DrawToBitmap(bmp, rect);
        foreach (Control ctrl in originalPanel.Controls)
        {
            ctrl.Visible = false;
        }
        using (Graphics g = Graphics.FromHwnd(originalPanel.Handle))
        {
            g.DrawImage(bmp, 0, 0);
            bmp.Dispose();
            SolidBrush brush = 
                new SolidBrush(Color.FromArgb(128, Color.Gray));
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }
        Panel floater = new Panel();
        floater.Size = originalPanel.Size;
        floater.Left = originalPanel.Left - 50;
        floater.Top = originalPanel.Top - 50;
        this.Controls.Add(floater);
        floater.BringToFront();
        return floater;
    }
