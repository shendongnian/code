    List<IPluginFactory> factories = new List<IPluginFactory>();
    
    try
    {
        foreach (Type type in assembly.GetTypes())
        {
            IPluginEnumerator instance = null;
    
            if (type.GetInterface("IPluginEnumerator") != null)
            {
                instance = (IPluginEnumerator)Activator.CreateInstance(type);
            }
    
            if (instance != null)
            {
                factories.AddRange(instance.EnumerateFactories());
            }
        }
    }
    catch (SecurityException ex)
    {
        throw new LoadPluginsFailureException("Loading of plugins failed.  Check the inner exception for more details.", ex);
    }
    catch (ReflectionTypeLoadException ex)
    {
        throw new LoadPluginsFailureException("Loading of plugins failed.  Check the inner exception for more details.", ex);
    }
    
    return factories.AsReadOnly();
