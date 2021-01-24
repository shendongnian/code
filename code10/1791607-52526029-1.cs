    public partial class Form1 : Form
    {
        private Rectangle _rect = new Rectangle(0, 0, 30, 30);
        private readonly Pen _pen = new Pen(Brushes.Chocolate);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _rect.Location = e.Location;
            Invalidate(ClientRectangle);
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //--improve graphics quality
            var g = e.Graphics;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            _rect.Offset(-15, -15); //--center rect
            e.Graphics.DrawRectangle(_pen, _rect);
            base.OnPaint(e);
        }
    }
