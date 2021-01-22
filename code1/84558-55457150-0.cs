    //Usage      
    var indexer = typeof(MyClass).GetIndexer(typeof(VehicleProperty));
    //Class
    public static class TypeExtensions
    {
      public static PropertyInfo GetIndexer(this Type type, params Type[] arguments) => type.GetProperties().First(x => x.GetIndexParameters().Select(y => y.ParameterType).SequenceEqual(arguments));
    }
