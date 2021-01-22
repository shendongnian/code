    TestClass sample = new TestClass();
    BindingFlags flags = BindingFlags.Instance | 
        BindingFlags.Public | BindingFlags.NonPublic;
    foreach (FieldInfo f in sample.GetType().GetFields(flags))
        Console.WriteLine("{0} = {1}", f.Name, f.GetValue(sample));
    foreach (PropertyInfo p in sample.GetType().GetProperties(flags))
        Console.WriteLine("{0} = {1}", p.Name, p.GetValue(sample, null));
