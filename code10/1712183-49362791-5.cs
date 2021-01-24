    public static List<Rectangle> GetSubRects(this Rectangle source, int size)
    {
       var rects = new List<Rectangle>();
    
       for (var x = 0; x < size; x++)
       {
          var width = Convert.ToInt32(Math.Floor(source.Width / (double)size));
          var xCal = 0;
    
          if (x == size - 1)
          {
             xCal = source.Width - (width * size);
          }
          for (var y = 0; y < size; y++)
          {
    
             var height = Convert.ToInt32(Math.Floor(source.Height / (double)size));
             var yCal = 0;
    
             if (y == size - 1)
             {
                yCal = source.Height - (height * size) ;
             }
    
             rects.Add(new Rectangle(width * x, height * y, width+ xCal, height + yCal));
          }
       }
    
       return rects;
    }
