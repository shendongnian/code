    public void InitializeSelectionOverlay()
    {
        this.olv1.HighlightForegroundColor = Color.Black;
        this.olv1.HighlightBackgroundColor = Color.White;
        this.olv1.AddDecoration(new SelectedRowDecoration());
    }
    public class SelectedRowDecoration : IOverlay
    {
        public void Draw(ObjectListView olv, Graphics g, Rectangle r) {
            if (olv.SelectedIndices.Count != 1)
                return;
            Rectangle rowBounds = olv.GetItem(olv.SelectedIndices[0]).Bounds;
            rowBounds.Inflate(0, 2);
            GraphicsPath path = this.GetRoundedRect(rowBounds, 15);
            g.DrawPath(new Pen(Color.Red, 2.0f), path);
        }
        private GraphicsPath GetRoundedRect(RectangleF rect, float diameter) {
            GraphicsPath path = new GraphicsPath();
            RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
