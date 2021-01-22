    Assembly assembly = Assembly.LoadFrom("ErroneusApp.exe");
    Type[] types= assembly.GetTypes();
    foreach (Type t in types)
    {
     MethodInfo method = t.GetMethod("Main",
         BindingFlags.Static | BindingFlags.NonPublic);
     if (method != null)
     {
        try
        {
            method.Invoke(null, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        break;
     }
    }
