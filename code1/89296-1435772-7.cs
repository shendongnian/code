    public class HeaderOverlay : AbstractOverlay
    {
        public override void Draw(ObjectListView olv, Graphics g, Rectangle r) {
            if (olv.View != System.Windows.Forms.View.Details)
                return;
            Point sides = NativeMethods.GetColumnSides(olv, olv.Columns.Count-1);
            if (sides.X == -1)
                return;
            RectangleF headerBounds = new RectangleF(sides.Y, 0, r.Right - sides.Y, 20);
            g.FillRectangle(Brushes.Red, headerBounds);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("In non-client area!", new Font("Tahoma", 9), Brushes.Black, headerBounds, sf);
        }
    }
