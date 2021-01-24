    using System.Drawing;
    using System.Drawing.Drawing2D;
    public partial class RoundControl : UserControl
    {
        private GraphicsPath GraphicsPathWithBorder;
        private float MyBaseWidth;
        private float m_PenSize = 2f;
        private Color m_BorderColor = Color.Yellow;
        private Color m_FillColor = Color.Green;
        public RoundControl()
        {
            this.ResizeRedraw = true;
            InitializeComponent();
            MyBaseWidth = Width;
        }
        public float BorderSize
        {
            get => this.m_PenSize;
            set {
                this.m_PenSize = value;
                this.Invalidate();
            }
        }
        public Color BorderColor
        {
            get => this.m_BorderColor;
            set {
                this.m_BorderColor = value;
                this.Invalidate();
            }
        }
        public Color FillColor
        {
            get => this.m_FillColor;
            set {
                this.m_FillColor = value;
                this.Invalidate();
            }
        }
        protected override void OnLayout(LayoutEventArgs e) {
            this.UpdateRegion();
            base.OnLayout(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rect = GraphicsPathWithBorder.GetBounds();
            float scaleX = 1 - ((m_PenSize + 1) / rect.Width);
            float scaleY = 1 - ((m_PenSize + 1) / rect.Height);
            using (Pen pen = new Pen(m_BorderColor, m_PenSize))
            using (Brush brush = new SolidBrush(m_FillColor))
            using (Matrix mx = new Matrix(scaleX, 0, 0, scaleY, pen.Width / 2, pen.Width / 2))
            {
                e.Graphics.Transform = mx;
                e.Graphics.FillPath(brush, GraphicsPathWithBorder);
                e.Graphics.DrawPath(pen, GraphicsPathWithBorder);
            }
        }
        private void UpdateRegion() {
            GraphicsPathWithBorder = RoundedCornerRectangle(ClientRectangle);
            Region = new Region(GraphicsPathWithBorder);
            this.Invalidate();
        }
        internal void SetZoomFactor(float z) {
            int newWidth = (int)(MyBaseWidth * z);
            if (newWidth <= (30 + this.m_PenSize * 2)) return;
            this.Width = newWidth;
            this.UpdateRegion();
        }
        private GraphicsPath RoundedCornerRectangle(Rectangle r)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = 10 * 2.4F;
            path.StartFigure();
            path.AddArc(r.X, r.Y, curveSize, curveSize, 180, 90);
            path.AddArc(r.Right - curveSize, r.Y, curveSize, curveSize, 270, 90);
            path.AddArc(r.Right - curveSize, r.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(r.X, r.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
