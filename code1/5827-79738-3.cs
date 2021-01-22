    string nspace = "...";
    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == nspace
            select t;
    q.ToList().ForEach(t => Console.WriteLine(t.Name));
