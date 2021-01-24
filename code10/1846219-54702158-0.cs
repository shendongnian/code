`C#
private void Child2_Shown(object sender, EventArgs e)
{
    Pen pen = new Pen(Color.Red, 2);
    Bitmap canvas = new Bitmap(Shape_PictureBox.Width, Shape_PictureBox.Height);
    Graphics graphics = Graphics.FromImage(canvas);
    int radius = 40;
    int x = 0;
    int y = radius;
    int xc = 50; 
    int yc = 50;
    int d = 3 - 2 * radius; 
    graphics.DrawLine(pen, xc, yc, x, y);
    while (y >= x)
    {
        x++;
        if (d > 0)
        {
            y--;
            d = d + 4 * (x - y) + 10;
        }
        else
        {
            d = d + 4 * x + 6;
        }
        // drawCircle(xc, yc, x, y); 
        graphics.DrawLine(pen, xc, yc, x, y); 
    }
    Shape_PictureBox.Image = canvas;
}
`
