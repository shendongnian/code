    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public partial class VerticalLabel : UserControl
    {
        public VerticalLabel()
        {
            InitializeComponent();
        }
    
        private void VerticalLabel_SizeChanged(object sender, EventArgs e)
        {
            GenerateTexture();
        }
    
        private void GenerateTexture()
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
    
            Bitmap img = new Bitmap(this.Height, this.Width);
            Graphics G = Graphics.FromImage(img);
    
            G.Clear(this.BackColor);
    
            SolidBrush brush_text = new SolidBrush(this.ForeColor);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            G.DrawString(this.Name, this.Font, brush_text, new Rectangle(0, 0, img.Width, img.Height), format);
            brush_text.Dispose();
    
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
     
            this.BackgroundImage = img;
        }
    }
