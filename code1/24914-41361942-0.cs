    private int YukseklikAyarla(string p, Font font, int maxWidth)
        {
            int iHeight = 0;
            using (Graphics g = CreateGraphics())
            {
                var sizes = g.MeasureString(p, font); // THE ONLY METHOD WE ARE ALLOWED TO USE
                iHeight = (int)Math.Round(sizes.Height);
                var multiplier = (int)Math.Round((double)sizes.Width) / maxWidth; // DIVIDING THE TEXT WIDTH TO SEE HOW MANY LINES IT CAN HAS
                if (multiplier > 0)
                {
                    iHeight = (int)(iHeight * (multiplier + 1)); // WE ADD 1 HERE BECAUSE THE TEXT ALREADY HAS A LINE
                }
            }
            return iHeight;
        }
 
