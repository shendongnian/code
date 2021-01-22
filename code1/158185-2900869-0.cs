    public static RGB HSBtoRGB(double h, double s, double b)
    {
        double r = 0;
        double g = 0;
        double b = 0;
    
        if(s == 0)
        {
            r = g = b = b;
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
    
            double p = b * (1.0 - s);
            double q = b * (1.0 - (s * fractionalSector));
            double t = b * (1.0 - (s * (1 - fractionalSector)));
    
            // assign the fractional colors to r, g, and b based on the sector
    
            // the angle is in.
    
            switch(sectorNumber)
            {
                case 0:
                    r = b;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = b;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = b;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = b;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = b;
                    break;
                case 5:
                    r = b;
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
