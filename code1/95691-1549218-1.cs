    var qry = (from type in assembly.GetTypes()
               where !string.IsNullOrEmpty(type.Namespace)
               let dotIndex = type.Namespace.IndexOf('.')
               let topLevel = dotIndex < 0 ? type.Namespace
                    : type.Namespace.Substring(0, dotIndex)
               orderby topLevel
               select topLevel).Distinct();
    foreach (var ns in qry) {
        Console.WriteLine(ns);
    }
