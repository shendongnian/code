        public void Draw(RenderWindow window)
        {
            var n = 8;
            var index = Math.Max(0, points.Count - n);
            var offset = Math.Min(points.Count, n);
            points.RemoveRange(index, offset);
         
            foreach (Point point in points)
            {
               point.Draw(window);
            }
         }
