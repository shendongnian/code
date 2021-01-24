    Bitmap source = new Bitmap("source.bmp");
    int border_thickness = 10;
    Bitmap destination = new Bitmap(source.Width + border_thickness, source.Height + border_thickness);
    Graphics g = Graphics.FromImage(destination);
    //draw a border
    SolidBrush brush = new SolidBrush(Color.Red);
    Rectangle rect = new Rectangle(0, 0, destination.Width, destination.Height);
    g.FillRectangle(brush, rect);
    //find the x/y position to put the image in center
    int x = (destination.Width - source.Width) / 2;
    int y = (destination.Height - source.Height) / 2;
    //draw the source image in to destination image
    g.DrawImage(source, x, y);
    destination.Save("destination.bmp");
