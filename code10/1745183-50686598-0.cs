    var dict = new Dictionary<string, object>
    {
        {"System.Int32", 3},
        {"System.String", "objectID"},
        {"System.Boolean", false}
    };
    var processValueMethod = typeof(/* type that contains ProcessValue */).GetMethod("ProcessValue");
    foreach (var entry in dict)
    {
        var t = Type.GetType(entry.Key);
        MethodInfo method = processValueMethod.MakeGenericMethod(t);
        method.Invoke(null, new []{entry.Value});
    }
