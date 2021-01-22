    public class InkPoint
    {
        public InkPoint(int x, int y)
        {
            point = new Point(x, y);
        }
        
        public Point point { get; set; }
        
        public static implicit operator Point(InkPoint p)
        {
            return p.point;
        }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        InkPoint[] inkPoints = { new InkPoint(1,2), new InkPoint(3,4) };
        Point[] points = Array.ConvertAll(inkPoints, x => x.point);
        
        Pen pen = new Pen(Color.Black, 1);
        e.Graphics.DrawLines(pen, points);
    }
