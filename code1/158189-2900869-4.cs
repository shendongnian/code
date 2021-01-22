    public static Color HSBtoRGB(double hue, double saturation, double brightness)
    {
        double r = 0;
        double g = 0;
        double b = 0;
    
        if (saturation == 0)
        {
            r = g = b = brightness;
        }
        else
        {
            // the color wheel consists of 6 sectors. Figure out which sector you're in.
            double sectorPos = hue / 60.0;
            int sectorNumber = (int)(Math.Floor(sectorPos));
            // get the fractional part of the sector
            double fractionalSector = sectorPos - sectorNumber;
    
            // calculate values for the three axes of the color. 
            double p = brightness * (1.0 - saturation);
            double q = brightness * (1.0 - (saturation * fractionalSector));
            double t = brightness * (1.0 - (saturation * (1 - fractionalSector)));
    
            // assign the fractional colors to r, g, and b based on the sector the angle is in.
            switch (sectorNumber)
            {
                case 0:
                    r = brightness;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = brightness;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = brightness;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = brightness;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = brightness;
                    break;
                case 5:
                    r = brightness;
                    g = p;
                    b = q;
                    break;
            }
        }
    
        return Color.FromArgb((int)(r * 255.0 + 0.5), (int)(g * 255.0 + 0.5), (int)(b * 255.0 + 0.5));
    }
