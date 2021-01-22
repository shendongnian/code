    public static RGB HSBtoRGB(double h, double s, double v)
    {
        double r = 0;
        double g = 0;
        double b = 0;
    
        if(s == 0)
        {
            r = g = b = v;
        }
        else
        {
            // the color wheel consists of 6 sectors. Figure out which sector
    
            // you're in.
    
            double sectorPos = h / 60.0;
            int sectorNumber = (int)(Math.Floor(sectorPos));
            // get the fractional part of the sector
    
            double fractionalSector = sectorPos - sectorNumber;
    
            // calculate values for the three axes of the color.
    
            double p = v * (1.0 - s);
            double q = v * (1.0 - (s * fractionalSector));
            double t = v * (1.0 - (s * (1 - fractionalSector)));
    
            // assign the fractional colors to r, g, and b based on the sector
    
            // the angle is in.
    
            switch(sectorNumber)
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }
        }
    
        return new RGB(
            Convert.ToInt32( Double.Parse(String.Format("{0:0.00}", r*255.0)) ),
            Convert.ToInt32( Double.Parse(String.Format("{0:0.00}", g*255.0)) ),
            Convert.ToInt32( Double.Parse(String.Format("{0:0.00}", b*255.0)) )
        );
    }
