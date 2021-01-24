    public class FontObject
    {
        private float CurrentScreenDPI = 0.0F;
        private float m_SizeInPoints = 0.0F;
        private float m_SizeInPixels = 0.0F;
        public FontObject() 
            : this(string.Empty, FontFamily.GenericSansSerif, FontStyle.Regular, 18F) { }
        public FontObject(string Text, Font font) 
            : this(Text, font.FontFamily, font.Style, font.SizeInPoints) { }
        public FontObject(string Text, FontFamily fontFamily, FontStyle fontStyle, float FontSize)
        {
            if (FontSize < 3) FontSize = 3;
            using (Graphics g = Graphics.FromHwndInternal(IntPtr.Zero)) {
                this.CurrentScreenDPI = g.DpiY; 
            }
            this.FontFamily = fontFamily;
            this.SizeInPoints = FontSize;
            this.FillColor = Color.White;
            this.Outline = new Pen(Color.Black, 1);
            this.Outlined = false;
        }
        public string Text { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontFamily FontFamily { get; set; }
        public Color FillColor { get; set; }
        public Pen Outline { get; set; }
        public bool Outlined { get; set; }
        public float SizeInPoints {
            get => this.m_SizeInPoints;
            set {  this.m_SizeInPoints = value;
                   this.m_SizeInPixels = (value * 72F) / this.CurrentScreenDPI;
                   this.SizeInEms = GetEmSize();
            }
        }
        public float SizeInPixels {
            get => this.m_SizeInPixels;
            set {  this.m_SizeInPixels = value;
                   this.m_SizeInPoints = (value * this.CurrentScreenDPI) / 72F;
                   this.SizeInEms = GetEmSize();
            }
        }
        public float SizeInEms { get; private set; }
        public PointF Location { get; set; }
        public RectangleF DrawingBox { get; set; }
        private float GetEmSize()
        {
            return (this.m_SizeInPoints * 
                    (this.FontFamily.GetCellAscent(this.FontStyle) +
                    this.FontFamily.GetCellDescent(this.FontStyle))) /
                    this.FontFamily.GetEmHeight(this.FontStyle);
        }
    }
