    static CommandBase GetInstance(string prefix)
    {       
        var currentAssembly = Assembly.GetExecutingAssembly();
        var concreteType = currentAssembly.GetMethods(BindingFlags.Public).Where(method => method.IsDefined(typeof(Command), false) &&  method.GetCustomAttribute<Command>().Prefix == prefix).FirstOrDefault();
        if (concreteType == null)
            throw new InvalidCastException($"No concrete type found for command: {prefix}");
        return (CommandBase)Activator.CreateInstance(concreteType);
    }
