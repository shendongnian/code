    public class Foo
    {
      public int Column1 { get; set; }
      public int Column2 { get; set; }
      ...
    }
      
    public static class FooExtensions
    {
      // I would use the actual type here instead of object if you know the type.
      public static object GetProperyValue(this Foo foo, string columnName)
      {
        var propertyInfo = foo.GetType().GetProperty(columnName);
        var value = propertyInfo.GetValue(foo);
        // as well as cast value to the type
        return value;
      }
    }
    ...
    query = query.Where(x => x.GetProperyValue(columnName) == searchValue);
    ...
