    Type t = something;
    System.Console.WriteLine("Author information for {0}", t);
    System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // reflection
    foreach (System.Attribute attr in attrs)
    {
        if (attr is Author)
        {
            Author a = (Author)attr;
                System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
        }
    }
