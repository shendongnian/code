    static class MyMath
    {
        public static double Sqrt(double _d)
        {
            double w = _d;
            double h = 1;
            double t = 0;
            if (h > w)
            {
                h = _d;
                w = 1;
            }
            while(true)
            {
                if (w < h)
                {
                    break;
                }
                w *= 0.5;
                h += h;
            }
            for (int i = 0; i < 5; i++)
            {
                t = ((w + h) * 0.5);
                h = ((h / t) * w);
                w = t;
            }
            return (t);
        }
    }
