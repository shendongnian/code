    foreach (var mi in typeof(X2).GetMethods())
    {
        if (mi.Name.Equals("GetName"))
        {
            Console.WriteLine("Method Name : {0}", mi.Name);
            var miPerms = mi.GetParameters();
            if (miPerms.Count() > 0)
                Console.WriteLine("Params : {0}", miPerms.Select(p => p.ParameterType + " " + p.Name).Aggregate((a, b) => a + "," + b));
        }
    }
