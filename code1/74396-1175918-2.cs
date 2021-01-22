    Type t = typeof(Environment);
    var c = t.GetConstructors(BindingFlags.Public);
    if (!t.IsAbstract && c.Length > 0)
    {
         //You can create instance
    }
