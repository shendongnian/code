    public class ExtendedPanel : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public ExtendedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.DoubleBuffered = false;
            this.UpdateStyles();
        }
        private int opacity = 1;
        [DefaultValue(1)]
        public int Opacity
        {
            get => this.opacity;
            set {
                if (value < 0 || value > 255) throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
                if (this.DesignMode) this.FindForm().Refresh();
                this.Invalidate();
            }
        }
        //protected override void OnPaintBackground(PaintEventArgs e) { }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (SolidBrush bgbrush = new SolidBrush(Color.FromArgb(this.opacity, this.BackColor)))
            {
                e.Graphics.FillRectangle(bgbrush, this.ClientRectangle);
            }
        }
    }
