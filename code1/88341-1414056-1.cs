    using System.Reflection;
    using System.IO;
    try
    {
        Assembly a = null;
        a = Assembly.LoadFrom(Application.StartupPath startupPath + "MyAssembly.dll"); 
        
        Type classType = a.GetType("MyNamespace.MyClass");
        object obj = Activator.CreateInstance(classType);
        MethodInfo mi = classType.GetMethod("MyMethod");
        
        mi.Invoke(obj, null);
    }
    catch (Exception e)
    {                 
        AddLog(e.Message);            
    }
