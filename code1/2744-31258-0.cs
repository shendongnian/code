    public IYourInterface GetClass(string className)
    {
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
        {
            foreach (Type type in asm.GetExportedTypes()) 
            {
               if (type.FullName == className)
                   return Activator.CreateInstance(type, constructorargs) as IYourInterface;
            }
        }
        return null;
    }
