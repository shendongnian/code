    private void ChangeTabColor(DrawItemEventArgs e)
    {
        Font TabFont;
        Brush BackBrush = new SolidBrush(Color.Green); //Set background color
        Brush ForeBrush = new SolidBrush(Color.Yellow);//Set foreground color
        if (e.Index == this.tabControl1.SelectedIndex)
        {
            TabFont = new Font(e.Font, FontStyle.Italic | FontStyle.Bold);
        }
        else
        {
            TabFont = e.Font;
        }
        string TabName = this.tabControl1.TabPages[e.Index].Text;
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        e.Graphics.FillRectangle(BackBrush, e.Bounds);
        Rectangle r = e.Bounds;
        r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
        e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
        //Dispose objects
        sf.Dispose();
        if (e.Index == this.tabControl1.SelectedIndex)
        {
            TabFont.Dispose();
            BackBrush.Dispose();
        }
        else
        {
            BackBrush.Dispose();
            ForeBrush.Dispose();
        }
    }
