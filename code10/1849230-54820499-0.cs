    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;
    [DesignerCategory("Code")]
    class AutoScaleLabel : Label
    {
        public AutoScaleLabel() => InitializeComponent();
        private void InitializeComponent()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            this.AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            using (StringFormat format = new StringFormat(StringFormatFlags.NoClip | 
                   StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox))
            {
                format.Trimming = StringTrimming.None;
                SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font, this.ClientSize, format);
                if (textSize.Width > this.ClientSize.Width)
                {
                    float scale = (float)this.ClientSize.Width / textSize.Width;
                    e.Graphics.ScaleTransform(scale, scale);
                }
                e.Graphics.Clear(this.BackColor);
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(this.Text, this.Font, brush, this.ClientRectangle, format);
            }
        }
    }
