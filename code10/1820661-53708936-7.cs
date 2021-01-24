    List<DrawingRectangle> DrawingRects = new List<DrawingRectangle>();
    public class DrawingRectangle
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Point StartPosition { get; set; }
        public Color DrawingcColor { get; set; } = Color.LightGreen;
        public float PenSize { get; set; } = 3f;
    }
    private void form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            DrawingRects.Add(new DrawingRectangle() {
                Location = e.Location, Size = Size.Empty, StartPosition = e.Location
            });
        }
    }
    private void form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            DrawingRectangle rect = DrawingRects.Last();
            if (e.Y < rect.StartPosition.Y) { rect.Location = new Point(rect.Location.Y, e.Y); }
            if (e.X < rect.StartPosition.X) { rect.Location = new Point(e.X, rect.Location.Y); }
            rect.Size = new Size(Math.Abs(rect.StartPosition.X - e.X), Math.Abs(rect.StartPosition.Y - e.Y));
            DrawingRects[DrawingRects.Count - 1] = rect;
            this.Invalidate();
        }
    }
    private void form1_Paint(object sender, PaintEventArgs e)
    {
        if (DrawingRects.Count == 0) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        foreach (var rect in DrawingRects) {
            using (Pen pen = new Pen(rect.DrawingcColor, rect.PenSize)) {
                e.Graphics.DrawRectangle(pen, new Rectangle(rect.Location, rect.Size));
            };
        }
    }
    private void btnClear_Click(object sender, EventArgs e)
    {
        DrawingRects.Clear();
        this.Invalidate();
    }
