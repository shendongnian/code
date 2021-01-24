    public class Ball : IDisposable
    {
        private SolidBrush brush = null;
        private int PrivateState = 0;
        public Ball()
            : this(new Point(40, 40)) { }
        public Ball(Point InitialPosition)
        {
            this.FillColorList();
            this.Centre = InitialPosition;
            this.Radius = 40;
            this.brush = new SolidBrush(this.Colors[this.PrivateState]);
        }
        public Point Centre { get; set; }
        public int State {
            get { return this.PrivateState; }
            set { this.PrivateState = (value < this.Colors.Count) ? value : 0; }
        }
        public int Radius { get; set; }
        public List<Color> Colors { get; set; }
        private void FillColorList()
        {
            this.Colors = new List<Color>() { Color.White, Color.Green, Color.Blue, Color.Red };
        }
        public void Draw(Graphics g)
        {
            this.brush.Color = this.Colors[this.PrivateState];
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.FillEllipse(brush, Centre.X - Radius, Centre.Y - Radius, 2 * Radius, 2 * Radius);
        }
        public void Move(Point NewCentre) => this.Centre = NewCentre;
        public void Dispose()
        {
            if (this.brush != null)
                this.brush.Dispose();
        }
    }
