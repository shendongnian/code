    Graphics g = e.ChartGraphics.Graphics;
    int pyc = (int)ay.ValueToPixelPosition(ay.Minimum);  // y-center
    for (int i = 0; i < 360 / ax.Interval; i++)
    {
        g.TranslateTransform(px, pyc);
        g.RotateTransform((float)(i * ax.Interval));
        g.TranslateTransform(-px, -pyc);
        g.DrawLine(Pens.colorOfYourChoice, px, py1, px, py2);
        g.ResetTransform();
    }
