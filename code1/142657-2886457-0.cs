    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
         e.DrawBackground();
        
         Graphics g = e.Graphics;
         g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
         ListBox lb = (ListBox)sender;
         g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
        
         e.DrawFocusRectangle();
    }
