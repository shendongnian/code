    string @namespace = "...";
    var types = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.IsClass && t.Namespace == @namespace)
        .ToList();
    types.ForEach(t => Console.WriteLine(t.Name));
