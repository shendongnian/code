    var assemblyName = "Some.Assembly.Name"
    var nameSpace = "Some.Namespace.Name";
    var className = "ClassNameFilter";
    var asm = Assembly.Load(assemblyName);
    var classes = asm.GetTypes().Where(p =>
         p.Namespace == nameSpace &&
         p.Name.Contains(className) 
    ).ToList();
