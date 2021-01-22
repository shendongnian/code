    using (Graphics g = Graphics.FromImage(newImage))
        {
             g.DrawImageUnscaled(original, 0, 0);
             using (SolidBrush brush = new SolidBrush(Color.Black))
             {
                    g.FillRectangle(brush, new Rectangle(x1value, y1value, x3value, y3value));
              }
        }
    pictureBox1.Image = newImage;
