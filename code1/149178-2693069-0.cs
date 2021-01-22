    public IEnumerable<string> GetMethodsOfReturnType(Type cls, Type ret)
    {
       // Did you really mean to prohibit public methods? I assume not
       var methods = cls.GetMethods(BindingFlags.NonPublic | 
                                    BindingFlags.Public |
                                    BindingFlags.Instance);
       var retMethods = methods.Where(m => m.ReturnType.IsAssignableFrom(ret))
                               .Select(m => m.Name);
       return retMethods;
    }
