    public partial class TransparentPictureBox : PictureBox
    {
        private Color tColor;
        public TransparentPictureBox()
        {
            InitializeComponent();
        }
        public new Image Image
        {
            get { return base.Image; }
            set
            {
                if (value == base.Image)
                    return;
                if (value != null)
                {
                    Bitmap bmp = new Bitmap(value);
                    tColor = bmp.GetPixel(0, 0);
                    this.Width = value.Width;
                    this.Height = value.Height;
                }
                base.Image = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            if (Image == null)
                return;
            ImageAttributes attr = new ImageAttributes();
            // Set the transparency color.
            attr.SetColorKey(tColor, tColor);
            
            Rectangle dstRect = new Rectangle(0, 0, base.Image.Width, base.Image.Height);
            e.Graphics.DrawImage(base.Image, dstRect, 0, 0, base.Image.Width, base.Image.Height, GraphicsUnit.Pixel, attr);
        }
    }
