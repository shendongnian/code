    Type genericType = typeof(IDataPointProcessor<>);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => genericType.IsAssignableFrom(p) && !p.IsAbstract).ToList();
    
    var dependedGenericType = genericType.MakeGenericType(typeof(DataPointInputBase));
    var method = dependedGenericType.GetMethod("GetOutput");
    var instance = Activator.CreateInstance(types[0]);
    method.Invoke(instance, new object[] { new DataPointInputBase() });
