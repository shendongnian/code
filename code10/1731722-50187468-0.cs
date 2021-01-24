        public void Draw(RenderWindow window)
        {
          var index = Math.Max(0, points.Count - 8);
          var offset = Math.Min(points.Count, 8);
          points.RemoveRange(index, offset);
         
          foreach (Point point in points)
          {
             point.Draw(window);
          }
         }
