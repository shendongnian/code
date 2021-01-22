    /// <summary>
    /// This is my main method
    /// </summary>
    /// <param name="args">You can pass command line args here</param>
    static void Main(string[] args)
    {
        var el = XElement.Load("ConsoleApplication18.XML");
        // obviously, improve this if necessary (might not work like this if DLL isn't already loaded)
        // you can use file paths
        var assemblyName = el.Descendants("assembly").FirstOrDefault();
        var assembly = Assembly.ReflectionOnlyLoad(assemblyName.Value);
        foreach (var member in el.Descendants("member").ToList()) // .ToList enables removing while traversing
        {
            var attr = member.Attribute("name");
            if (attr == null)
            {
                continue;
            }
            var name = attr.Value;
            if (name.StartsWith("T:"))
            {
                var typeName = name.Substring(2);
                var type = assembly.GetType(typeName, false, false);
                if (type == null || !type.IsVisible)
                {
                    member.Remove();
                }
            }
            else if (name.StartsWith("M:"))
            {
                var fullName = name.Substring(2);
                var parameterList = fullName.IndexOf('(');
                if (parameterList == -1)
                {
                    parameterList = fullName.Length;
                }
                var split = fullName.LastIndexOf('.', parameterList - 1);
                var typeName = fullName.Substring(0, split);
                var type = assembly.GetType(typeName, false, false);
                if (type == null || !type.IsVisible)
                {
                    member.Remove();
                    continue;
                }
                var methodName = fullName.Substring(split + 1, parameterList - (split + 1));
                if (methodName == "#ctor")
                {
                    var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);
                    if (ctor == null || !ctor.IsFamily || !ctor.IsPublic)
                    {
                        member.Remove();
                        continue;
                    }
                }
                var method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (method == null || !method.IsFamily || !method.IsPublic)
                {
                    member.Remove();
                    continue;
                }
            }
        }
        el.Save("ConsoleApplication18-public.XML");
    }
}
