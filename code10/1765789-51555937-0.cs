    Bitmap dayToolTipBackground = new Bitmap(200, 200);
    private void toolTipDay_Popup(object sender, PopupEventArgs e)
    {
         e.ToolTipSize = new Size(200, 200);
         var backGraphics = Graphics.FromImage(dayToolTipBackground);
         var cursorPosition = Cursor.Position;
         backGraphics.CopyFromScreen(new Point(Cursor.Position.X, Cursor.Position.Y + 21), new Point(0, 0), new Size((200, 200)));    
    }
    
    
    private void toolTipDay_Draw(object sender, DrawToolTipEventArgs e)
    {
         e.Graphics.DrawImage(dayToolTipBackground, new Point(0, 0));
         e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.Red)), new Rectangle(e.Bounds.Location, e.Bounds.Size));
    }
