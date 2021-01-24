    private delegate void CommandInvoker(Action<CommandContext> configure);
    private static CommandInvoker CreateCommandInvoker(MethodInfo method)
    {
        return cfg =>
        {
            var commandContext = (CommandContext)Activator.CreateInstance(method.DeclaringType);
            cfg(commandContext);
            method.Invoke(commandContext, null);
        };
    }
    private static readonly IReadOnlyDictionary<string, CommandInvoker> commandCache = Assembly.GetEntryAssembly()
        .GetTypes()
        .Where(t => t.IsSubclassOf(typeof(CommandContext)) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
        .SelectMany(t => t.GetMethods(), (t, m) => new { Method = m, Attribute = m.GetCustomAttribute<CommandAttribute>() })
        .Where(it => it.Attribute != null)
        .ToDictionary(it => it.Attribute.Text, it => CreateCommandInvoker(it.Method));
    // now MessageReceived becomes as simple as:
    private void MessageReceived(object sender, MessageEventArgs e)
    {
        string rawMessage = "/message";
        if (rawMessage.StartsWith('/') && commandCache.TryGetValue(rawMessage.Substring(1), out CommandInvoker invokeCommand))
            invokeCommand(ctx => ctx.Message = rawMessage);
    }
