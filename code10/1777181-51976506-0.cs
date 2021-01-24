    var ctors = typeof(A).GetConstructors();
    // assuming class A has only one constructor
    var ctor = ctors[0];
    foreach (var param in ctor.GetParameters())
    {
        Console.WriteLine(string.Format(
            "Param {0} is named {1} and is of type {2}",
            param.Position, param.Name, param.ParameterType));
    }
