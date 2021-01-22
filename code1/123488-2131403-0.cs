    private void button1_Click(object sender, EventArgs e)
        {
            this.ForeColor = System.Drawing.Color.Red;
            using (Graphics g = this.CreateGraphics())
            {
                Brush b = new SolidBrush(System.Drawing.Color.Blue);
                g.DrawString("SAMPLE TEXT", SystemFonts.CaptionFont, b, new PointF(50, 50));
                b.Dispose();
            }
        }
