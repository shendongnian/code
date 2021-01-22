    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
    object[] attributes = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyFileVersionAttribute), false);
    object attribute = null;
    if (attributes.Length > 0)
    {
        attribute = attributes[0] as System.Reflection.AssemblyFileVersionAttribute;
    }
