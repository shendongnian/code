        static void Main()
        {
            Bitmap bmp=new Bitmap("test.jpg");
            
            int width = bmp.Width;
            int height = bmp.Height;
            Dictionary<Point, int> currentLayer = new Dictionary<Point, int>();
            currentLayer[new Point(0, 0)] = 0;
            currentLayer[new Point(width - 1, height - 1)] = 0;
            while (currentLayer.Count != 0)
            {
                foreach (Point p in currentLayer.Keys)
                    bmp.SetPixel(p.X, p.Y, Color.Black);
                Dictionary<Point, int> newLayer = new Dictionary<Point, int>();
                foreach (Point p in currentLayer.Keys)
                    foreach (Point p1 in Neighbors(p, width, height))
                        if (Distance(bmp.GetPixel(p1.X, p1.Y), Color.White) < 40)
                            newLayer[p1] = 0;
                currentLayer = newLayer;
            }
            bmp.Save("test2.jpg");
        }
        static int Distance(Color c1, Color c2)
        {
            int dr = Math.Abs(c1.R - c2.R);
            int dg = Math.Abs(c1.G - c2.G);
            int db = Math.Abs(c1.B - c2.B);
            return Math.Max(Math.Max(dr, dg), db);
        }
        static List<Point> Neighbors(Point p, int maxX, int maxY)
        {
            List<Point> points=new List<Point>();
            if (p.X + 1 < maxX) points.Add(new Point(p.X + 1, p.Y));
            if (p.X - 1 >= 0) points.Add(new Point(p.X - 1, p.Y));
            if (p.Y + 1 < maxY) points.Add(new Point(p.X, p.Y + 1));
            if (p.Y - 1 >= 0) points.Add(new Point(p.X, p.Y - 1));
            return points;
        }
