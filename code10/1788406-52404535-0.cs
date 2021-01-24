    private static T ConvertVector(T[] values)
    {
        var maxX = float.MinValue;
        var maxY = float.MinValue;
        var minX = float.MaxValue;
        var minY = float.MaxValue;
    
        
    
        foreach (var point in values)
        {
            maxX = Mathf.Max(point.x, maxX);
            minX = Mathf.Min(point.x, minX);
            maxY = Mathf.Max(point.y, maxY);
            minY = Mathf.Min(point.y, minY);
        }
    
      var genericType = typeof(T).Name;
      if (Vector2.GetType().Name.Equals(genericType ))
      {
        var result = new Vector2 [4]
        {
            new Vector2(minX, minY),
            new Vector2(maxX, maxY),
            new Vector2(maxX, minY),
            new Vector2(minX, maxY),
        };
        return result;
       }
    
      if (Vector3.GetType().Name.Equals(genericType ))
      {
        var result = new Vector3 [4]
        {
            new Vector3(minX, minY),
            new Vector3(maxX, maxY),
            new Vector3(maxX, minY),
            new Vector3(minX, maxY),
        };
        return result;
       }
     throw new NotImplementedException($"The type '{genericType }' is not supported for conversion");
    }
