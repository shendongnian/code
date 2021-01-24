       public static double Sqrt(double _d)
       {
           double w = _d, h = 1, t = 0;
           if (w < 1)
           {
               h = _d;
               w = 1;
           }
           do
           {
               w *= 0.5;
               h += h;
           } while (w > h);
           for (int i = 0; i < 4; i++)
           {
               t = ((w + h) * 0.5);
               h = ((h / t) * w);
               w = t;
           }
           return (((w + h) * 0.5));
       }
