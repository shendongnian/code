    MyDataContext db = new MyDataContext();
    Assembly assembly = Assembly.GetExecutingAssembly();
    Type t = assembly.GetType("Namespace." + strTableName);
    if (t != null)
    {
        var foos = db.GetTable(t);
 
        foreach (var f in foos)
        {
            PropertyInfo pi = f.GetType().GetProperty("Foo");
            int value = (int)pi.GetValue(f, null);
            Console.WriteLine(value);
        }
    }
