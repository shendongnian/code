    [Designer(typeof(ParentControlDesigner))]
    public partial class CustomPanel : UserControl
    {
        Color _borderColor = Color.Blue;
        int _borderWidth = 5;
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; 
                Invalidate();
                PerformLayout();
            }
        }
        public CustomPanel()  { InitializeComponent(); }
        public override Rectangle DisplayRectangle
        {
            get 
            { 
                return new Rectangle(_borderWidth, _borderWidth, Bounds.Width - _borderWidth * 2, Bounds.Height - _borderWidth * 2); 
            }
        }
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }
        new public BorderStyle BorderStyle
        {
            get { return _borderWidth == 0 ? BorderStyle.None : BorderStyle.FixedSingle; }
            set  { }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen p = new Pen(_borderColor, _borderWidth))
                { 
                    Rectangle r = ClientRectangle; 
                    // now for the funky stuff...
                    // to get the rectangle drawn correctly, we actually need to 
                    // adjust the rectangle as .net centers the line, based on width, 
                    // on the provided rectangle.
                    r.Inflate(-Convert.ToInt32(_borderWidth / 2.0 + .5), -Convert.ToInt32(_borderWidth / 2.0 + .5));
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetDisplayRectLocation(_borderWidth, _borderWidth);
        }
    }
