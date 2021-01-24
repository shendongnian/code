    sealed class PictureBoxWithText : PictureBox
    {
        public Point TextLocation { get; set; }
    
        public override void OnPaint(PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 12))
                e.Graphics.DrawString(Text, myFont, Brushes.White, TextLocation);
        }
    }
