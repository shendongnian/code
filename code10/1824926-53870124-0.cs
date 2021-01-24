    Image image = new Bitmap(2000, 1024);
    
    Graphics graph = Graphics.FromImage(image);
    
    graph.Clear(Color.Azure);
    
    Pen pen = new Pen(Brushes.Black);
    
    graph.DrawLines(pen, new Point[] { new Point(10,10), new Point(800, 900) });
    
    Rectangle rect = new Rectangle(100, 100, 300, 300);
    graph.DrawRectangle(pen, rect);    
    image.Save("myImage.png", System.Drawing.Imaging.ImageFormat.Png);
