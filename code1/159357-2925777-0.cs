    var dict = new Dictionary<string, string>();
    var type = dict.GetType();
    var typeName = type.FullName;
    var newType = Type.GetType(typeName);
    Console.WriteLine(type == newType); //true
