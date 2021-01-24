        private Bitmap floodfill(Bitmap input, Point pt, Color target, Color replacementColor, int r_tol, int g_tol, int b_tol)
        {
            Stack<Point> pixels = new Stack<Point>();
            Stack<Color> colour = new Stack<Color>();
            pixels.Push(pt);
            colour.Push(target);
            while (pixels.Count > 0)
            {
                var current_pixels = pixels.Pop();
                var current_colour = colour.Pop();
                var a = new Point(current_pixels.X, current_pixels.Y);
                Color targetColor = current_colour;
                if (a.X < input.Width && a.X > 0 && a.Y < input.Height && a.Y > 0)
                {
                    var green = Math.Abs(targetColor.G - input.GetPixel(a.X, a.Y).G) < r_tol;
                    var red = Math.Abs(targetColor.R - input.GetPixel(a.X, a.Y).R) < g_tol;
                    var blue = Math.Abs(targetColor.B - input.GetPixel(a.X, a.Y).B) < b_tol;
                    if (red == true && blue == true && green == true)
                    {
                        var old_pixels = input.GetPixel(a.X, a.Y);
                        input.SetPixel(a.X, a.Y, replacementColor);
                        pixels.Push(new Point(a.X - 1, a.Y));
                        colour.Push(old_pixels);
                        pixels.Push(new Point(a.X + 1, a.Y));
                        colour.Push(old_pixels);
                        pixels.Push(new Point(a.X, a.Y - 1));
                        colour.Push(old_pixels);
                        pixels.Push(new Point(a.X, a.Y + 1));
                        colour.Push(old_pixels);
                    }
                }
            }
            return input;
        }
