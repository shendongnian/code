    static Dictionary<string, Type> prefixMapping;
    
    static Program()
    {
        prefixMapping = currentAssembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(CommandBase)) && t.IsDefined(typeof(CommandAttribute), false) && !t.IsAbstract)
            .Select(t => new { t, p = t.GetCustomAttribute<CommandAttribute>().Prefix })
            .GroupBy(x => x.p)
            .ToDictionary(g => g.Key, g => g.First().t);
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
