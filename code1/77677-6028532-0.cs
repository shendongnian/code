        protected void Stamp(Bitmap b, DateTime dt, string format)
        {
            string stampString;
            if (!string.IsNullOrEmpty(format)) { stampString = dt.ToString(format); }
            else { stampString = dt.ToString(); }
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.Black, 0, 0, b.Width, 20);
            g.DrawString(stampString, new Font("Arial", 12f), Brushes.White, 2, 2);
        }
