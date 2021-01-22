    Func<Type, bool> isBad = t => t.Assembly == badAssembly;
    var types = yourAssembly.GetTypes();
    var methods = types.SelectMany(t => t.GetMethods()).ToArray());
    var badMethods = methods.Where(m => isBad(m.ReturnType) 
        || m.GetParameters().Any(p => isBad(p.ParameterType));
    var properties = types.SelectMany(t => t.GetProperties()).ToArray();
    var badProperties = properties.Where(p => isBad(p.PropertyType));
