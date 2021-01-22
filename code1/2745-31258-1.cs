    public IYourInterface GetClass(string className)
    {
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
        {            
            foreach (Type type in asm.GetTypes())
            {
                if (type.Name == className)
                    o = Activator.CreateInstance(type) as IYourInterface;
            }   
        }
        return null;
    }
