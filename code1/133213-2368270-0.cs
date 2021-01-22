    public void RedBlueShift(Bitmap bmp, double factor)
    {
        byte R = 0;
        byte G = 0;
        byte B = 0;
        byte Rmax = 0;
        byte Gmax = 0;
        byte Bmax = 0;
        double avg = 0;
        double normal = 0;
        if (factor > 1)
        {
            factor = 1;
        }
        else if (factor < -1)
        {
            factor = -1;
        }
        for (int x = 0; x < bmp.Width; x++)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                Color color = bmp.GetPixel(x, y);
                R = color.R;
                G = color.G;
                B = color.B;
                avg = (double)(R + G + B) / 3;
                normal = avg / 255.0; // to preserve overall intensity
                if (factor < 0) // red-tinted:
                {
                    if (normal < .5)
                    {
                        Rmax = (byte)((normal / .5) * 255);
                        Gmax = 0;
                        Bmax = 0;
                    }
                    else
                    {
                        Rmax = 255;
                        Gmax = (byte)(((normal - .5) * 2) * 255);
                        Bmax = Gmax;
                    }
                    R = (byte)((double)R - ((double)(R - Rmax) * -factor));
                    G = (byte)((double)G - ((double)(G - Gmax) * -factor));
                    B = (byte)((double)B - ((double)(B - Bmax) * -factor));
                }
                else if (factor > 0) // blue-tinted:
                {
                    if (normal < .5)
                    {
                        Rmax = 0;
                        Gmax = 0;
                        Bmax = (byte)((normal / .5) * 255);
                    }
                    else
                    {
                        Rmax = (byte)(((normal - .5) * 2) * 255);
                        Gmax = R;
                        Bmax = 255;
                    }
                    R = (byte)((double)R - ((double)(R - Rmax) * factor));
                    G = (byte)((double)G - ((double)(G - Gmax) * factor));
                    B = (byte)((double)B - ((double)(B - Bmax) * factor));
                }
                color = Color.FromArgb(R, G, B);
                bmp.SetPixel(x, y, color);
            }
        }
    }
