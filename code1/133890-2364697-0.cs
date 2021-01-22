           List<PointF> lpf = new List<PointF>();
        lpf.Add(new PointF(27.8F, 32.62F));
        lpf.Add(new PointF(99.3F, 147.273F));
        lpf.Add(new PointF(7.5F, 1412.2F));
        Console.WriteLine();
        foreach( PointF p in lpf )
        {
            Console.WriteLine(p);
        }
        List<Point> lp = lpf.ConvertAll( 
            new Converter<PointF, Point>(PointFToPoint));
        Console.WriteLine();
        foreach( Point p in lp )
        {
            Console.WriteLine(p);
        }
