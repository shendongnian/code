    public static Image RotateImage(Image img, float rotationAngle)
    {
        using (Graphics graphics = Graphics.FromImage(img))
        {
            graphics.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
            graphics.RotateTransform(rotationAngle);
            graphics.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
            graphics.DrawImage(img, new Point(0, 0));
            GraphicsPath gp = new GraphicsPath();
            GraphicsUnit gu = GraphicsUnit.Pixel;
            gp.AddRectangle(graphics.ClipBounds);
            gp.AddRectangle(img.GetBounds(ref gu));
            graphics.FillPath(Brushes.White, gp);
        }
        return img;
    }
