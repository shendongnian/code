    Assembly assm = Assembly.LoadFrom(@"C:\Balaji\Test\a.dll");
    foreach (Type tp in assm.GetTypes())
    {
        if (tp.IsClass)
        {
            MethodInfo mi = tp.GetMethod("OnStart");
            if (mi != null)
            {
                object obj = Activator.CreateInstance(tp);
                mi.Invoke(obj,null);
                break;
            }
        }
     }
