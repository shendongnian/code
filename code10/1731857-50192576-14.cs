    static CommandBase GetInstance(string prefix)
    {       
        var currentAssembly = Assembly.GetExecutingAssembly();
        var concreteType = currentAssembly.GetTypes().Where(commandClass => commandClass.IsDefined(typeof(CommandAttribute), false) && commandClass.GetCustomAttribute<CommandAttribute>().Prefix == prefix).FirstOrDefault();
        if (concreteType == null)
            throw new InvalidCastException($"No concrete type found for command: {prefix}");
        return (CommandBase)Activator.CreateInstance(concreteType);
    }
