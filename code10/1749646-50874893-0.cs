    private void panel1_Paint(object sender, PaintEventArgs e)
    {
         if(NeedsToBeDrawn)
         {
                Rectangle rect = new Rectangle(10, 10, 80, 90);
                rect.Inflate(-10, -10);
                e.Graphics.DrawRectangle(black, rect);
                e.Graphics.FillRectangle(Brushes.BlueViolet, rect);
                StringFormat f = new StringFormat();
                f.LineAlignment = StringAlignment.Center;
                f.Alignment = StringAlignment.Center;
                e.Graphics.DrawString("Hello", this.Font, Brushes.GhostWhite, rect, f);
         }
    }
