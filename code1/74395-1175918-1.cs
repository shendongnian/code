    Type t = typeof(Environment);
    var c = t.GetConstructor(Type.EmptyTypes);
    if (c != null && c.IsPublic)
    {
         //You can create instance
    }
