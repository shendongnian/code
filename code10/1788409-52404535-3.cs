    public static VectorExtensions{
      public static Vector2[] ToConvertedVector(this Vector2[] values)
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
    
        var result = new Vector2 [4]
        {
            new Vector2(minX, minY),
            new Vector2(maxX, maxY),
            new Vector2(maxX, minY),
            new Vector2(minX, maxY),
        };
    
        return result;
    }
    }
