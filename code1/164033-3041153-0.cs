    public void AddWatermark(string filename, string watermarkText, Stream outputStream) {
        Bitmap bitmap = Bitmap.FromFile(filename);
        Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
        Color color = Color.FromArgb(10, 0, 0, 0); //Adds a black watermark with a low alpha value (almost transparent).
        Point atPoint = new Point(100, 100); //The pixel point to draw the watermark at (this example puts it at 100, 100 (x, y)).
        SolidBrush brush = new SolidBrush(color);
    
        Graphics graphics = null;
        try {
            graphics = Graphics.FromImage(bitmap);
        } catch {
            Bitmap temp = bitmap;
            bitmap = new Bitmap(bitmap.Width, bitmap.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(temp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            temp.Dispose();
        }
    
        graphics.DrawString(text, font, brush, atPoint);
        graphics.Dispose();
    
        bitmap.Save(outputStream);
    }
