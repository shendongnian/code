    List<DrawingRect> DrawingRects = new List<DrawingRect>();
    Point StartingPosition = Point.Empty;
    Color DrawingcColor = Color.LightGreen;
    float PenSize = 3.0f;
    public class DrawingRect
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
    }
    private void form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            StartingPosition = e.Location;
            DrawingRects.Add(new DrawingRect() { Location = e.Location, Size = Size.Empty });
        }
    }
    private void form1_MouseUp(object sender, MouseEventArgs e)
    {
        DrawingRects.Last().Size = new Size(e.Location.X - DrawingRects.Last().Location.X, 
                                            e.Location.Y - DrawingRects.Last().Location.Y);
    }
    private void form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Rectangle rect = new Rectangle(DrawingRects.Last().Location, DrawingRects.Last().Size);
            if (e.Y < StartingPosition.Y) { rect.Y = e.Y; }
            if (e.X < StartingPosition.X) { rect.X = e.X; }
            rect.Size = new Size(Math.Abs(StartingPosition.X - e.X), Math.Abs(StartingPosition.Y - e.Y));
            DrawingRects.Last().Location = rect.Location;
            DrawingRects.Last().Size = rect.Size;
            this.panCanvas.Invalidate();
        }
    }
    private void form1_Paint(object sender, PaintEventArgs e)
    {
        if (DrawingRects.Count == 0) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (Pen pen = new Pen(DrawingcColor, PenSize)) {
            foreach (var item in DrawingRects) {
                e.Graphics.DrawRectangle(pen, new Rectangle(item.Location, item.Size));
            }
        };
    }
    private void btnClear_Click(object sender, EventArgs e)
    {
        DrawingRects.Clear();
        this.panCanvas.Invalidate();
    }
