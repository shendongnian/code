    using System.Drawing;
    class myLabel:System.Windows.Forms.Label
    {
        public int RotateAngle { get; set; }  // to rotate your text
        public string NewText { get; set; }   // to draw text
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush b =new SolidBrush(this.ForeColor);           
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font,b , 0f, 0f);
            base.OnPaint(e);
        }
    }
