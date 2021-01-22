        var qry = (from type in Assembly.GetExecutingAssembly().GetTypes()
                   let ns = type.Namespace ?? "" // some are null
                   where !ns.Contains(".") // top-level only
                   orderby ns // sorted
                   select ns).Distinct(); // once only
        foreach (var ns in qry) {
            Console.WriteLine(ns);
        }
