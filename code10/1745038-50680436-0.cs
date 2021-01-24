    private bool IsPointValid(Point point, IEnumerable<CustomRectangle> rectangles)
    {
         var firstMatch = rectangles.FirstOrDefault(r => r.Rectangle.Contains(point) && !r.IsChecked);
    
         if (firstMatch != null)
             firstMatch.IsChecked = true;
    
         return firstMatch != null; 
    }
