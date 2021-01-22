    System.Reflection.Assembly info = typeof(System.Environment).Assembly;
    
    Type t = info.GetType("System.Environment");
    MethodInfo m = t.GetMethod("GetFolderPath");
    
    object result = m.Invoke(null, arguments);
