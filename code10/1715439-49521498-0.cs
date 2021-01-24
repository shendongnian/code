    public class CircularPictureBox : PictureBox
    {
        private Bitmap bitmap;
        private Color borderColor;
        private int penSize;
        private Color AlphaColor = Color.FromArgb(0, 255,255,255);
        private bool enhancedBuffering;
        public CircularPictureBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint | 
                          ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void InitializeComponent()
        {
            this.enhancedBuffering = true;
            this.bitmap = null;
            this.borderColor = Color.Silver;
            this.penSize = 7;
            this.BackColor = AlphaColor;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(100, 100);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.CompositingMode = CompositingMode.SourceOver;
            //pe.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            //pe.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (this.Region != null)
                pe.Graphics.Clip = this.Region;
            Rectangle rect = this.ClientRectangle;
            if (this.bitmap != null) 
                pe.Graphics.DrawImage(this.bitmap, rect);
            rect.Inflate(-this.penSize / 2 + 1, -this.penSize / 2 + 1);
            pe.Graphics.DrawEllipse(new Pen(this.borderColor, this.penSize), rect);
        }
        protected override void OnResize(EventArgs e)
        {
            using (GraphicsPath gpath = new GraphicsPath())
            {
                gpath.AddEllipse(this.ClientRectangle);
                gpath.CloseFigure();
                using (Region region = new Region(gpath))
                    this.Region = region.Clone();
            }
        }
        [Description("Gets or Sets the Image diplayed by the control."), Category("Appearance")]
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public Bitmap Bitmap
        {
            get { return this.bitmap; }
            set { this.bitmap = value; this.Invalidate(); }
        }
        [Description("Gets or Sets the size of the Border"), Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public int BorderSize
        {
            get { return this.penSize; }
            set { this.penSize = value; this.Invalidate(); }
        }
        [Description("Gets or Sets the Color of Border drawn around the Image.")]
        [Category("Appearance")]
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; this.Invalidate(); }
        }
        [Description("Enables or disables the control OptimizedDoubleBuffering feature")]
        [Category("Useful Features")] //<= "Useful feature" is a custom category
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public bool EnhancedBuffering
        {
            get { return this.enhancedBuffering; }
            set { this.enhancedBuffering = value; 
                  this.SetStyle(ControlStyles.OptimizedDoubleBuffer, value); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public new Image ErrorImage
        {
            get { return null; }
            set { base.ErrorImage = null; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public new Image InitialImage
        {
            get { return null; }
            set { base.InitialImage = null; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public new Image BackgroundImage
        {
            get { return null; }
            set { base.BackgroundImage = null; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), BrowsableAttribute(false)]
        public new Image Image {
            get { return null; }
            set { base.Image = null; } 
        }
    }
