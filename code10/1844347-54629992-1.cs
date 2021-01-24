    private Bitmap AddBorder(Image original_image, int border_size, Color border_color)
        {
            Size originalSize = new Size(original_image.Width + border_size, original_image.Height + border_size);
            Bitmap bmp = new Bitmap(originalSize.Width, originalSize.Height);
            Rectangle rec = new Rectangle(new Point(0, 0), originalSize);
            Pen pen = new Pen(border_color, border_size);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawRectangle(pen, rec);
            rec.Inflate(-border_size /2, -border_size /2);
            g.DrawImage(original_image, rec);
            return bmp;
        }
