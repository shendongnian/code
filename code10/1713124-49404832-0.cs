    List<Color> getColorByAngle(Bitmap bmp, float angle)
    {
        List<Color> colors = new List<Color>();
        int cx = bmp.Width / 2;
        int cy = bmp.Height / 2;
        float a = angle;
        float r = Math.Min(bmp.Width, bmp.Height) / 2f;
        if ( (a > 45 && a < 135) || (a >225  && a < 315))
        {
            for (int y = (int)cy; y < cy + r; y++)
            {
                int x = (int)(Math.Cos(a * Math.PI / 180f) * r) + cx;
                colors.Add(bmp.GetPixel(x, y));
            }
        }
        else
        {
            for (int x = (int)cx; x < cx + r; x++)
            {
                int y = (int)(Math.Sin(a * Math.PI / 180f) * r) + cy;
                colors.Add(bmp.GetPixel(x, y));
            }
        }
        return colors;
    }
