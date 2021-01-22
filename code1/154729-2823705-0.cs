            Bitmap orig = new Bitmap(imageFileName);
            Graphics origG = Graphics.FromImage(orig);
            int dim = Math.Max(orig.Width, orig.Height);
            Bitmap dest = new Bitmap(dim, dim, origG);
            using (Graphics g = Graphics.FromImage(dest))
            {
                Pen white = new Pen(Color.White, 22);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, dim, dim);
                g.DrawImage(orig, new Point((dim - orig.Width) / 2, (dim - orig.Height) / 2));
            }
            dest.Save(newFileName);
