    var variableTypes = new List<VariableType>
    {
        new VariableType
        {
            Name = "Integer Types",
            DataTypes = new List<string>{ "sbyte", "byte", "short", "ushort" }
        },
        new VariableType
        {
            Name = "Real Floating Point Types",
            DataTypes = new List<string>{ "float", "double" }
        }
    };
    foreach(var variableType in variableTypes)
    {
        Console.WriteLine(variableType.Name + " : " + string.Join(", ", variableType.DataTypes));
    }
