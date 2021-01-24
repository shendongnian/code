    using System.Drawing;
    using System.Drawing.Drawing2D;
    public partial class RoundedControl : UserControl
    {
        private GraphicsPath GraphicsPathWithBorder;
        private float MyBaseWidth;
        private float m_PenSize = 2f;
        private Color m_BorderColor = Color.Yellow;
        private Color m_FillColor = Color.Green;
        public RoundedControl()
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
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            this.UpdateRegion();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(m_BorderColor, m_PenSize))
            using (Brush brush = new SolidBrush(m_FillColor))
            {
                using (Matrix mx = new Matrix())
                {
                    RectangleF rect = GraphicsPathWithBorder.GetBounds();
                    mx.Scale(1 - (pen.Width * 2 / rect.Width), 1 - (pen.Width * 2 / rect.Height));
                    mx.Translate(pen.Width, pen.Width);
                    e.Graphics.Transform = mx;
                    e.Graphics.FillPath(brush, GraphicsPathWithBorder);
                    e.Graphics.DrawPath(pen, GraphicsPathWithBorder);
                }
            }
        }
        private void UpdateRegion()
        {
            GraphicsPathWithBorder = RoundedCornerRectangle(ClientRectangle);
            Region = new Region(GraphicsPathWithBorder);
            this.Invalidate();
        }
        internal void SetZoomFactor(float z)
        {
            int newWidth = (int)(MyBaseWidth * z);
            if (newWidth <= (30 + this.m_PenSize * 2)) return;
            this.Width = newWidth;
            this.UpdateRegion();
        }
        internal GraphicsPath RoundedCornerRectangle(Rectangle r)
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
