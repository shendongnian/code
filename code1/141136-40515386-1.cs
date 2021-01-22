    Type t = o.GetType();
    foreach (PropertyInfo pi in t.GetProperties())
    {
        IEnumerable<NoHtmlOutput> attributes = pi.GetCustomAttributes<NoHtmlOutput>();
        foreach (NoHtmlOutput attribute in attributes)
        {
          Console.WriteLine(attribute);
        }
    }
