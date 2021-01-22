        public static Image FloodFill(this Image img, Point pt, Color color)
        {
            Stack<Point> pixels = new Stack<Point>();
            var targetColor = ((Bitmap)img).GetPixel(pt.X, pt.Y);
            pixels.Push(pt);
            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                if (a.X < img.Width && a.X > -1 && a.Y < img.Height && a.Y > -1)
                {
                    if (((Bitmap)img).GetPixel(a.X, a.Y) == targetColor)
                    {
                        ((Bitmap)img).SetPixel(a.X, a.Y, color);
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
            }
            return img;
        }
