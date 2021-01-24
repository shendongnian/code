    const double Deg2Rad = Math.PI / 180d;
    const int innerSize = 100;
    const int outerSize = 25;
    
    const int circle_count = 9;
    
    int centre_X = this.Width / 2;
    int centre_Y = this.Height / 2;
    
    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
    double step = 360d / circle_count;
                
    for (double angle = 0; angle< 360d; angle += step)
    {
        int X = (int)(centre_X + Math.Cos(angle * Deg2Rad) * innerSize);
        int Y = (int)(centre_Y + Math.Sin(angle * Deg2Rad) * innerSize);
    
        e.Graphics.FillEllipse(Brushes.Green, new Rectangle(X - (outerSize / 2), Y - (outerSize / 2), outerSize, outerSize));
    }
    
    Graphics l = e.Graphics;
    Pen p = new Pen(Color.Gray, 5);
    l.DrawEllipse(p, centre_X - (innerSize / 2), centre_Y - (innerSize / 2), innerSize, innerSize);
    l.Dispose();
