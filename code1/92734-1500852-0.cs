            public static Color ColorFromAhsb(int a, float h, float s, float b)
        {
            if (0 > a || 255 < a)
            {
                throw new Exception("a");
            }
            if (0f > h || 360f < h)
            {
                throw new Exception("h");
            }
            if (0f > s || 1f < s)
            {
                throw new Exception("s");
            }
            if (0f > b || 1f < b)
            {
                throw new Exception("b");
            }
            if (0 == s)
            {
                return Color.FromArgb(a, Convert.ToInt32(b * 255),
                  Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }
            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;
            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }
            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }
            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);
            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(a, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(a, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(a, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(a, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(a, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(a, iMax, iMid, iMin);
            }
    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var bmp = new Bitmap("c:\\bw.bmp");
            
            foreach (int y in Enumerable.Range(0, bmp.Height - 1))
            { 
                foreach (int x in Enumerable.Range(0,bmp.Width-1))
                {
                    var p = bmp.GetPixel(x, y);
                    var h = p.GetHue();
                    
                    var c = ColorFromAhsb(p.A, p.GetHue() + 200, p.GetSaturation() + 0.5f, p.GetBrightness());
                    bmp.SetPixel(x, y, c);                    
                }
            }
            pictureBox1.Image = bmp;
            //bmp.Dispose();
        }
