    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Globalization;
    using System.Windows.Forms;
    
    [DesignerCategory("Code")]
    class RoundCenterLabel : Label, INotifyPropertyChanged
    {
        internal int WS_EX_TRANSPARENT = 0x00000020;
        internal Font m_CustomFont = null;
        internal Color m_BackGroundColor;
        internal int m_InnerPadding = 0;
        internal int m_FontPadding = 25;
        internal int m_Opacity = 128;
        public event PropertyChangedEventHandler PropertyChanged;
        public RoundCenterLabel() => InitializeComponent();
        private void InitializeComponent()
        {
            this.SetStyle(ControlStyles.Opaque |
                          ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.m_CustomFont = new Font("Segoe UI", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            this.BackColor = Color.LimeGreen;
            this.ForeColor = Color.White;
            this.Text = "NN";
        }
        private void NotifyPropertyChanged(string PropertyName) {
            this.Invalidate();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public new Font Font {
            get => this.m_CustomFont;
            set { this.m_CustomFont = value;
                  NotifyPropertyChanged(nameof(this.Font));
            }
        }
        public override string Text {
            get => base.Text;
            set { base.Text = value;
                  NotifyPropertyChanged(nameof(this.Text));
                Form parent = this.FindForm();
                if (parent != null && parent.IsHandleCreated) { parent.Refresh(); }
            }
        }
        public int InnerPadding {
            get => this.m_InnerPadding;
            set { this.m_InnerPadding = CheckValue(value, 0, this.ClientRectangle.Height - 10);
                  NotifyPropertyChanged(nameof(this.InnerPadding)); }
        }
        public int FontPadding {
            get => this.m_FontPadding;
            set { this.m_FontPadding = CheckValue(value, 0, this.ClientRectangle.Height - 10);
                  NotifyPropertyChanged(nameof(this.FontPadding));
            }
        }
        public int Opacity {
            get => this.m_Opacity;
            set { this.m_Opacity = CheckValue(value, 0, 255);
                  UpdateBackColor(this.m_BackGroundColor);
                  NotifyPropertyChanged(nameof(this.Opacity));
            }
        }
        public override Color BackColor {
            get => this.m_BackGroundColor;
            set { UpdateBackColor(value);
                  NotifyPropertyChanged(nameof(this.BackColor));
            }
        }
        protected override void OnLayout(LayoutEventArgs evt) {
            base.OnLayout(evt);
            base.AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit, CultureInfo.CurrentUICulture.LCID)
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using (SolidBrush CircleBrush = new SolidBrush(this.m_BackGroundColor))
            using (SolidBrush ForeBrush = new SolidBrush(this.ForeColor))
            {
                this.FontAdapter(this.m_CustomFont, e.Graphics.DpiY);
                RectangleF rect = InnerRectangle();
                e.Graphics.FillEllipse(CircleBrush, rect);
                e.Graphics.DrawString(this.Text, this.m_CustomFont, ForeBrush, rect, format);
            }
        }
        private RectangleF InnerRectangle()
        {
            Tuple<decimal, decimal> refSize = GetMinMax(this.ClientRectangle.Height, this.ClientRectangle.Width);
            SizeF size = new SizeF((float)refSize.Item1 - (this.m_InnerPadding / 2), 
                                   (float)refSize.Item1 - (this.m_InnerPadding / 2));
            PointF position = new PointF((this.ClientRectangle.Width - size.Width) / 2,
                                         (this.ClientRectangle.Height - size.Height) / 2);
            return new RectangleF(position, size);
        }
        private void FontAdapter(Font font, float Dpi)
        {
            RectangleF rect = InnerRectangle();
            float FontSize = CheckValue((int)(rect.Height - this.m_FontPadding), 6, 
                                        (int)(rect.Height - this.m_FontPadding)) / (Dpi / 72.0F);
            using (Font customfont = new Font(font.FontFamily, FontSize, font.Style, GraphicsUnit.Pixel))
                this.m_CustomFont = (Font)customfont.Clone();
        }
        private void UpdateBackColor(Color color)
        {
            this.m_BackGroundColor = Color.FromArgb(this.m_Opacity, Color.FromArgb(color.R, color.G, color.B));
            base.BackColor = this.m_BackGroundColor;
        }
        private int CheckValue(int Value, int Min, int Max)
        {
            return (Value < Min) ? Min : ((Value > Max) ? Max : Value);
        }
        private Tuple<decimal, decimal> GetMinMax(ValueType Value1, ValueType Value2)
        {
            if ((Value1 is Enum) || (Value1.GetType().IsNested)) return null;
            if ((Value2 is Enum) || (Value2.GetType().IsNested)) return null;
            return new Tuple<decimal, decimal>(Math.Min(Convert.ToDecimal(Value1), Convert.ToDecimal(Value2)),
                                               Math.Max(Convert.ToDecimal(Value1), Convert.ToDecimal(Value2)));
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
