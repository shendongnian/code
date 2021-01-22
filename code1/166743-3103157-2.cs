    IPlugin plugin = ...;
    
    IRunnablePlugin runnable = plugin as IRunnablePlugin;
    IRunnableParamPlugin param = plugin as IRunnableParamPlugin;
    
    XmlDocument output;
    
    if(param != null)
    {
        output = param.RunPlugin(parameter);
    }
    else if(runnable != null)
    {
        output = runnable.RunPlugin();
    }
    else
    {
        throw new InvalidOperationException();
    }
