    public IEnumerable<string> GetMethodsOfReturnType(Type cls, Type ret)
    {
       var methods = cls.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
       var retMethods = methods.Where(m => m.ReturnType.IsSubclassOf(ret) || m.ReturnType == ret)
                               .Select(m => m.Name);
       return retMethods;
    }
