    internal class MyPoints : IDisposable
    {
        bool IsDisposed = false;
        public MyPoints() => DrawingPoints = new List<DrawingPoint>();
        public List<DrawingPoint> DrawingPoints { get; set; }
        public void Add(DrawingPoint NewPoint)
        {
            if (NewPoint.Dot.Size.Width > 1 && NewPoint.Dot.Size.Height > 1)
                DrawingPoints.Add(NewPoint);
        }
        public void Clear()
        {
            this.Dispose();
            this.DrawingPoints.Clear();
            this.DrawingPoints = new List<DrawingPoint>();
        }
        public void Remove(Point point)
        {
            Remove(this.DrawingPoints.Select((p, i) => { if (p.Dot.Contains(point)) return i; return -1; }).First());
        }
        public void Remove(int Index)
        {
            if (Index > -1)
            {
                this.DrawingPoints[Index].Delete();
                this.DrawingPoints.RemoveAt(Index);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool IsSafeDisposing)
        {
            if (IsSafeDisposing && (!this.IsDisposed) && (this.DrawingPoints.Count > 0))
            {
                foreach (DrawingPoint dp in this.DrawingPoints)
                    if (dp != null) dp.Delete();
            }
        }
        public class DrawingPoint
        {
            Pen m_Pen = null;
            Rectangle m_Dot = Rectangle.Empty;
            public DrawingPoint() : this(Point.Empty) { }
            public DrawingPoint(Point newPoint)
            {
                this.m_Pen = new Pen(Color.Red, 1);
                this.m_Dot = new Rectangle(newPoint, new Size(2, 2));
            }
            public Pen DrawingPen { get => this.m_Pen; set => this.m_Pen = value; }
            public Rectangle Dot { get => this.m_Dot; set => this.m_Dot = value; }
            public void Delete()
            {
                if (this.m_Pen != null) this.m_Pen.Dispose();
            }
        }
    }
