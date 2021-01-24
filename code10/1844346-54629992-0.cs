    private Bitmap AddBorder(Image original_image, int border_size, Color border_color)
        {
            Size originalSize = original_image.Size;
            Bitmap bmp = new Bitmap(originalSize.Width, originalSize.Height);
            Rectangle rec = new Rectangle(new Point(0, 0), originalSize);
            Pen pen = new Pen(border_color, border_size);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawRectangle(pen, rec);
            Image ShrinkImage = original_image.GetThumbnailImage(original_image.Width - border_size, original_image.Height - border_size, null, new IntPtr());
            rec.Inflate(-border_size /2, -border_size /2);
            g.DrawImage(ShrinkImage, rec);
            return bmp;
        }
