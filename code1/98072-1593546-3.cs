    var method = (from type in assembly.GetTypes()
                  where type.IsClass
                  let onStartMethod = type.GetMethod("OnStart",
                      BindingFlags.Static | BindingFlags.Public)
                  where onStartMethod != null
                  select onStartMethod).FirstOrDefault();
    if (method != null)
    {
        method.Invoke(null, new Object[0]); // assumes no parameters
    }
