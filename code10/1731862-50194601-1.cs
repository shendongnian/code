    static Dictionary<string, Type> prefixMapping;
    
    static Program()
    {
        prefixMapping = currentAssembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(CommandBase)) && !t.IsAbstract)
            .Select(t => new { t, c = (CommandBase)Activator.CreateInstance(t) })
            .ToDictionary(x => x.t.GetProperty("Prefix").GetValue(x.c).ToString(), x => x.t);
    }
    
    static CommandBase GetInstance(string prefix)
    {
        Type concreteType;
        if ( prefixMapping.TryGetValue(prefix, out concreteType) )
        {
            return (CommandBase)Activator.CreateInstance(concreteType);
        }
        return default(CommandBase);
    }
