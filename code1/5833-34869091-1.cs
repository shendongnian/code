    var asm = Assembly.Load("Some.Assembly.Name");
    var nameSpace = "Some.Namespace.Name";
    var classes = asm.GetTypes().Where(p =>
         p.Namespace == nameSpace &&
         p.Name.Contains("ClassNameFilter") 
    ).ToList();
