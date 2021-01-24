    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Globalization;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Linq;
    
    namespace Configuration.CodeMess
    {
        public class TransparentLabel : Label, INotifyPropertyChanged
        {
            internal int WS_EX_TRANSPARENT = 0x00000020;
            //internal Font m_CustomFont = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Pixel);
            //internal Color m_BackGroundColor;
            //internal int m_InnerPadding = 20;
            //internal int m_FontPadding = 5;
            //internal int m_Opacity = 50;
            public event PropertyChangedEventHandler PropertyChanged;
            public TransparentLabel() => InitializeComponent();
            public void InitializeComponent()
            {
                this.SetStyle(ControlStyles.Opaque |
                              ControlStyles.SupportsTransparentBackColor |
                              ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
                this.Refresh();
            }
            //protected override void OnPaint(PaintEventArgs e)
            //{
            //    if (Parent != null)
            //    {
            //        using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            //        {
            //            Parent.Controls.Cast<Control>()
            //                  .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
            //                  .Where(c => c.Bounds.IntersectsWith(this.Bounds))
            //                  .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
            //                  .ToList()
            //                  .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));
    
    
            //            e.Graphics.DrawImage(bmp, -Left, -Top);
            //            using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
            //            {
            //                e.Graphics.FillRectangle(b, this.ClientRectangle);
            //            }
            //            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent);
            //        }
            //    }
            //}
    
            private int opacity;
            public int Opacity
            {
                get { return opacity; }
                set
                {
                    if (value >= 0 && value <= 255)
                        opacity = value;
                    this.Invalidate();
                }
            }
    
            public Color transparentBackColor;
            public Color TransparentBackColor
            {
                get { return transparentBackColor; }
                set
                {
                    transparentBackColor = value;
                    this.Invalidate();
                }
            }
    
            [Browsable(false)]
            public override Color BackColor
            {
                get
                {
                    return Color.Transparent;
                }
                set
                {
                    base.BackColor = Color.Transparent;
                }
            }
            //public new Font Font
            //{
            //    get => this.m_CustomFont;
            //    set
            //    {
            //        this.FontAdapter(value);
            //        NotifyPropertyChanged(nameof(this.Font));
            //    }
            //}
            //public int InnerPadding
            //{
            //    get => this.m_InnerPadding;
            //    set
            //    {
            //        this.m_InnerPadding = CheckValue(value, 0, this.ClientRectangle.Height - 10);
            //        NotifyPropertyChanged(nameof(this.InnerPadding));
            //    }
            //}
            //public int FontPadding
            //{
            //    get => this.m_FontPadding;
            //    set
            //    {
            //        this.m_FontPadding = CheckValue(value, 0, this.ClientRectangle.Height - 10);
            //        NotifyPropertyChanged(nameof(this.FontPadding));
            //    }
            //}
            //public int Opacity
            //{
            //    get => this.m_Opacity;
            //    set
            //    {
            //        this.m_Opacity = CheckValue(value, 0, 255);
            //        this.BackColor = Color.FromArgb(this.m_Opacity, this.BackColor);
            //        NotifyPropertyChanged(nameof(this.Opacity));
            //    }
            //}
            //public override Color BackColor
            //{
            //    get => this.m_BackGroundColor;
            //    set
            //    {
            //        this.m_BackGroundColor = Color.FromArgb(this.m_Opacity, value);
            //        base.BackColor = this.m_BackGroundColor;
            //        NotifyPropertyChanged(nameof(this.BackColor));
            //    }
            //}
            //private void NotifyPropertyChanged(string PropertyName)
            //{
            //    this.Refresh();
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            //}
            //protected override void OnLayout(LayoutEventArgs evt)
            //{
            //    base.OnLayout(evt);
            //    base.AutoSize = false;
            //    this.Opacity = this.m_Opacity;
            //}
            protected override void OnPaint(PaintEventArgs e)
            {
                StringFormat format = new StringFormat(StringFormatFlags.LineLimit, CultureInfo.CurrentUICulture.LCID)
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent);
                //using (SolidBrush CircleBrush = new SolidBrush(this.BackColor))
                //using (SolidBrush ForeBrush = new SolidBrush(this.ForeColor))
                //{
                //    this.FontAdapter(this.m_CustomFont);
                //    RectangleF rect = InnerRectangle();
                //    e.Graphics.FillEllipse(CircleBrush, rect);
    
                //    e.Graphics.DrawString(this.Text, this.m_CustomFont, format);
                //}
            }
            //private RectangleF InnerRectangle()
            //{
            //    Tuple<decimal, decimal> refSize = GetMinMax(this.ClientRectangle.Height, this.ClientRectangle.Width);
            //    SizeF size = new SizeF((float)refSize.Item1 - (this.m_InnerPadding / 2),
            //                           (float)refSize.Item1 - (this.m_InnerPadding / 2));
            //    PointF position = new PointF((this.ClientRectangle.Width - size.Width) / 2,
            //                                 (this.ClientRectangle.Height - size.Height) / 2);
            //    return new RectangleF(position, size);
            //}
            //private void FontAdapter(Font font)
            //{
            //    RectangleF rect = InnerRectangle();
            //    float FontSize = (CheckValue((int)(rect.Height - this.m_FontPadding), 6,
            //                                 (int)(rect.Height - this.m_FontPadding)) / 1.4F);
            //    using (Font customfont = new Font(font.FontFamily, FontSize, font.Style, GraphicsUnit.Pixel))
            //        this.m_CustomFont = (Font)customfont.Clone();
            //}
            //private int CheckValue(int Value, int Min, int Max)
            //{
            //    return (Value < Min) ? Min : ((Value > Max) ? Max : Value);
            //}
            //private Tuple<decimal, decimal> GetMinMax(ValueType Value1, ValueType Value2)
            //{
            //    if ((Value1 is Enum) || (Value1.GetType().IsNested)) return null;
            //    if ((Value2 is Enum) || (Value2.GetType().IsNested)) return null;
            //    return new Tuple<decimal, decimal>(Math.Min(Convert.ToDecimal(Value1), Convert.ToDecimal(Value2)),
            //                                       Math.Max(Convert.ToDecimal(Value1), Convert.ToDecimal(Value2)));
            //}
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams parms = base.CreateParams;
                    parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                    return parms;
                }
            }
        }
    }
