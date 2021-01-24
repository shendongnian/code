    bmp = new Bitmap(1500, 1500); 
    using (Graphics g = Graphics.FromImage(bmp))
        g.Clear(Color.White);
    e.Graphics.DrawLines(pen, points.ToArray()); 
    points.Clear();
