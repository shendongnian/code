                if (e.Button == MouseButtons.Left)
                
                {
                    rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
                    rectangles.Add(rect);
                    pictureBox1.Invalidate();
                    f = 0;
                }
           
        }
