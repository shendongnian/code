    listbox1.DrawItem += new DrawItemEventHandler(listbox1_DrawItem);
    listbox1.ItemHeight = 16;
    private void listbox1_DrawItem(object sender, DrawItemEventArgs e)
           { 
    e.DrawBackground();
            e.DrawFocusRectangle();
            Rectangle bounds = e.Bounds;
            Size imageSize = new Size(16, 16);
            Bitmap b;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            Rectangle rc = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 5, e.Bounds.Height - 3);
             UseObject s ;
             if (e.Index >= 0)
             {
                 s = (UseObject)listbox1.Items[e.Index];
                 b = new Bitmap(s.Img, imageSize);
                 e.Graphics.DrawImage(b, e.Bounds.X, e.Bounds.Y);
                 e.Graphics.DrawString(s.Str, new Font("Verdana", 10, FontStyle.Bold), new SolidBrush(Color.Black), rc, sf);
             }
            }
