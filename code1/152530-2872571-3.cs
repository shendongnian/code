                    else if (label1.TextAlign == ContentAlignment.TopCenter)
                    {
                        SizeF size = e.Graphics.MeasureString(label1.Text, label1.Font);
                        float left = ((float)this.Width + label1.Left) / 2 - size.Width / 2;
                        RectangleF rect1 = new RectangleF(left, (float)label1.Top, size.Width, label1.Height);
                        e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect1);
                    }
                    else
                    {
                        SizeF size = e.Graphics.MeasureString(label1.Text, label1.Font);
                        float left = (float)label1.Width - size.Width + label1.Left;
                        RectangleF rect1 = new RectangleF(left, (float)label1.Top, size.Width, label1.Height);
                        e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect1);
                    }
               }
        }
            
