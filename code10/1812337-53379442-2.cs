    class TransparentPanel : Panel
    {
        internal const int WS_EX_TRANSPARENT = 0x00000020;
        public TransparentPanel() => InitializeComponent();
        protected void InitializeComponent()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.Opaque |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }
        protected override CreateParams CreateParams
        {
            get {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= WS_EX_TRANSPARENT;
                return parameters;
            }
        }
    }
