    private class OverlayPanel : Panel
    {
        internal int WS_EX_TRANSPARENT = 0x00000020;
        public OverlayPanel(Control RefControl)
        {
            InitializeComponent();
            this.Size = new Size(RefControl.Size.Width - SystemInformation.VerticalScrollBarWidth,
                                 RefControl.Size.Height - SystemInformation.HorizontalScrollBarHeight);
            this.Location = RefControl.Location;
        }
        private void InitializeComponent()
        {
            this.SetStyle(ControlStyles.Opaque | 
                          ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.BorderStyle = BorderStyle.None;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= WS_EX_TRANSPARENT;
                return parameters;
            }
        }
    }
