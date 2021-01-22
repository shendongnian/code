    string @namespace = "...";
    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == @namespace
            select t;
    q.ToList().ForEach(t => Console.WriteLine(t.Name));
