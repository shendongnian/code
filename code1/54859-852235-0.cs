    Type t = obj.GetType();//where obj is object whose properties you need.
    PropertyInfo [] pi =t.GetProperties();
    foreach (PropertyInfo p in pi)
    {
        System.Console.WriteLine(p.Name + "    " + p.GetType);
    }
