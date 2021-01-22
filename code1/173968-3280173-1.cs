    public static class ArrayExtensions
    {
        public static Point RoundIndexToPoint(int index, int radius)
        {
            if (radius == 0)
                return new Point(0, 0);
            Point result = new Point(-radius, -radius);
            while (index < 0) index += radius * 8;
            index = index % (radius * 8);
            int edgeLen = radius * 2;
            if (index < edgeLen)
            {
                result.X += index;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.X = radius;
                result.Y += index;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.X = radius - index;
                result.Y = radius;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.Y = radius - index;
            }
            return result;
        }
        public static T[,] Rotate45<T>(this T[,] array)
        {
            int dim = Math.Max(array.GetLength(0), array.GetLength(0));
            T[,] result = new T[dim, dim];
            Point center = new Point((result.GetLength(0) - 1) / 2, (result.GetLength(1) - 1) / 2);
            Point center2 = new Point((array.GetLength(0) - 1) / 2, (array.GetLength(1) - 1) / 2);
            for (int r = 0; r <= (dim - 1) / 2; r++)
            {
                for (int i = 0; i <= r * 8; i++)
                {
                    Point source = RoundIndexToPoint(i, r);
                    Point target = RoundIndexToPoint(i + r, r);
                    if (!(center2.X + source.X < 0 || center2.Y + source.Y < 0 || center2.X + source.X >= array.GetLength(0) || center2.Y + source.Y >= array.GetLength(1)))
                        result[center.X + target.X, center.Y + target.Y] = array[center2.X + source.X, center2.Y + source.Y];
                }
            }
            return result;
        }     
    }
