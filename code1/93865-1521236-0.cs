        protected override void OnPaint(PaintEventArgs e)
        {
            float x = 10.0F;
            float y = 10.0F;
            
            string drawString = "123";
            Font drawFont = new Font("Arial", 16);
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (char c in drawString.ToCharArray())
            {
                PointF p = new PointF(x, y);
                e.Graphics.DrawString(c.ToString(), drawFont, brush, p);
                y += drawFont.Height;
            }
            base.OnPaint(e);
        }
