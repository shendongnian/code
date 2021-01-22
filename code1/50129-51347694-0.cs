    public partial class CFProgressBar : ProgressBar
    {
        public CFProgressBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent) { }
        protected override void OnPaint(PaintEventArgs e)
        {
            double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));
            int currentWidth = (int)((double)Width * scaleFactor);
            Rectangle rect;
            if (this.RightToLeftLayout)
            {
                int currentX = Width - currentWidth;
                rect = new Rectangle(currentX, 0, this.Width, this.Height);
            }
            else
                rect = new Rectangle(0, 0, currentWidth, this.Height);
            if (rect.Width != 0)
            {
                SolidBrush sBrush = new SolidBrush(ForeColor);
                e.Graphics.FillRectangle(sBrush, rect);
            }
        }
    }
