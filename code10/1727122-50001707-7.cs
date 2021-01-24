    void updateStripLine(Chart chart, ChartArea ca, string name)
    {
         // find our stripline; one could pass in a class level variable as well
        StripLine sl = ca.AxisY.StripLines.Cast<StripLine>()
                               .Where(s => s.Tag.ToString() == name).FirstOrDefault();
        if (sl != null)  // either clean-up the resources..
        {
            var oldni = chart.Images.FindByName(name);
            if (oldni != null)
            {
                oldni.Image.Dispose();
                chart.Images.Remove(oldni);
                oldni.Dispose();
            }
        }
        else  // or, create the line
        {
            sl = new StripLine();
            sl.Tag = name;
            ca.AxisY.StripLines.Add(sl);
        }
        ca.RecalculateAxesScale();
        RectangleF ipr = InnerPlotPositionClientRectangle(chart, ca);
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        double f1 = ax.ScaleView.ViewMinimum / (ax.Maximum - ax.Minimum);
        double f2 = ax.ScaleView.ViewMaximum / (ax.Maximum - ax.Minimum);
        Bitmap b0 = (Bitmap)chart.Images["spectrum"].Image;
        int x  = (int)(b0.Width * f1);
        int xx = (int)(b0.Width * f2);
        Rectangle srcR = new Rectangle( x, 0, xx - x, b0.Height);
        Rectangle tgtR = Rectangle.Round(new RectangleF(0,0, ipr.Width , 10)); 
        // create bitmap and namedImage:
        Bitmap bmp = new Bitmap( tgtR.Width, tgtR.Height);
        using (Graphics g = Graphics.FromImage(bmp))
             {  g.DrawImage(b0, tgtR, srcR, GraphicsUnit.Pixel);  }
        NamedImage ni = new NamedImage(name, bmp);
        chart.Images.Add(ni);
        sl.BackImageWrapMode = ChartImageWrapMode.Scaled;
        sl.StripWidth =  ay.PixelPositionToValue(0) - ay.PixelPositionToValue(12);
        sl.Interval = 100;  // make large enough to avoid another sLine showing up
        sl.IntervalOffset = 0;
        sl.BackImage = name;
    }
