    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(1.0F, -1.0F);
            e.Graphics.TranslateTransform(0.0F, -(float)Height);
            e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(Width, Height));
            base.OnPaint(e);
        }
    }
