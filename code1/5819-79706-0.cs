    using System.Reflection;
    using System.Collections.Generic;
    //...
    
    static List<string> GetClasses(string namespace)
    {
        Assembly asm = asm.GetExecutingAssembly();
        
        List<string> namespacelist = new List<string>();
        List<string> classlist = new List<string>();
    
        foreach (Type type in asm.GetTypes())
        {
            if (type.Namespace == namespace)
                namespacelist.Add(type.Name);
        }
    
        foreach (string classname in namespacelist)
            classlist.Add(classname);
    
        return classlist;
    }
