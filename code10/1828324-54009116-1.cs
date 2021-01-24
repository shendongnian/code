    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    ..
    Pen pen = new Pen(Color.FromArgb(125, 0, 0, 255), 15);
    var graphics = Graphics.FromImage(bmp);
    graphics.Clear(Color.White);
    graphics.DrawLines(pen, points1);
    graphics.DrawLines(pen, points2);
    bmp.Save("D:\\__x19DL", ImageFormat.Png);
    graphics.Clear(Color.White);
    using (GraphicsPath gp = new GraphicsPath())
    {
        gp.AddLines(points1);
        gp.StartFigure();
        gp.AddLines(points2);
        graphics.DrawPath(pen, gp);
        bmp.Save("D:\\__x19GP", ImageFormat.Png);
    }
