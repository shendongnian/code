    using System.Collections.Generic;
    using System.Linq;
     
    public static class F
    {
        /// <summary>
               /// Floods the fill.
               /// </summary>
               /// <typeparam name="T"></typeparam>
               /// <param name="source">The source.</param>
               /// <param name="x">The x.</param>
               /// <param name="y">The y.</param>
               /// <param name="width">The width.</param>
               /// <param name="height">The height.</param>
               /// <param name="target">The target to replace.</param>
               /// <param name="replacement">The replacement.</param>
        public static void FloodFill<T>(this T[] source, int x, int y, int width, int height, T target, T replacement)
        {
            int i = 0;
     
            FloodFill(source, x, y, width, height, target, replacement, out i);
        }
     
        /// <summary>
               /// Floods the array following Flood Fill algorithm
               /// </summary>
               /// <typeparam name="T"></typeparam>
               /// <param name="source">The source.</param>
               /// <param name="x">The x.</param>
               /// <param name="y">The y.</param>
               /// <param name="width">The width.</param>
               /// <param name="height">The height.</param>
               /// <param name="target">The target to replace.</param>
               /// <param name="replacement">The replacement.</param>
               /// <param name="i">The iterations made (if you want to debug).</param>
        public static void FloodFill<T>(this T[] source, int x, int y, int width, int height, T target, T replacement, out int i)
        {
            i = 0;
     
            // Queue of pixels to process. :silbar:
            HashSet<int> queue = new HashSet<int>();
     
            queue.Add(Pn(x, y, width));
     
            while (queue.Count > 0)
            {
                int _i = queue.First(),
                  _x = _i % width,
                  _y = _i / width;
     
                queue.Remove(_i);
     
                if (source[_i].Equals(target))
                    source[_i] = replacement;
     
                for (int offsetX = -1; offsetX < 2; offsetX++)
                    for (int offsetY = -1; offsetY < 2; offsetY++)
                    {
                        // do not check origin or diagonal neighbours
                        if (offsetX == 0 && offsetY == 0 || offsetX == offsetY || offsetX == -offsetY || -offsetX == offsetY)
                            continue;
     
                        int targetIndex = Pn(_x + offsetX, _y + offsetY, width);
                        int _tx = targetIndex % width,
                          _ty = targetIndex / width;
     
                        // skip out of bounds point
                        if (_tx < 0 || _ty < 0 || _tx >= width || _ty >= height)
                            continue;
     
                        if (!queue.Contains(targetIndex) && source[targetIndex].Equals(target))
                        {
                            queue.Add(targetIndex);
                            ++i;
                        }
                    }
            }
        }
     
        public static int Pn(int x, int y, int w)
        {
            return x + (y * w);
        }
    }
