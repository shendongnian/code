    public static class FieldExtensions
    {
      public static IEnumerable<FieldInfo> GetFields( this Type type, int depth )
      {
        if( level == 0 )
          return Enumerable.Empty<FieldInfo>();
      
        FieldInfo[] fields = type.GetFields();
        return fields.Union(fields.Where( fi => !fi.IsPrimitive )
                                  .SelectMany( f => f.FieldType.GetFields( depth -1 ) );
      }
    }
