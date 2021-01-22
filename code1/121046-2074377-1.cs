    var measure = g.MeasureString(line, f);
    int width = (int)measure.Width;
    int height = (int)measure.Height;
    using (Bitmap b = new Bitmap(width, height)) {
      using (Graphics bg = Graphics.FromImage(b)) {
        bg.Clear(Color.Transparent);
        using (Brush black = new SolidBrush(Color.Black)) {
          bg.DrawString(line, f, black, 0, 0);
        }
      }
      b.Save(savepoint+line+".png", System.Drawing.Imaging.ImageFormat.Png); 
    }
