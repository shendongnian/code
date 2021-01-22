    public static string TranslateExceptionMessage(Exception ex, CultureInfo targetCulture)
    {
        try
        {
            Assembly assembly = ex.GetType().Assembly;
            ResourceManager resourceManager = new ResourceManager(assembly.GetName().Name, assembly);
            ResourceSet originalResources = resourceManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, createIfNotExists: true, tryParents: true);
            ResourceSet targetResources = resourceManager.GetResourceSet(targetCulture, createIfNotExists: true, tryParents: true);
            foreach (DictionaryEntry originalResource in originalResources)
                if (originalResource.Value.ToString().Equals(ex.Message.ToString(), StringComparison.Ordinal))
                    return targetResources.GetString(originalResource.Key.ToString(), ignoreCase: false); // success
    
        }
        catch { }
        return ex.Message; // failed (error or cause it's not smart enough to find texts with '{0}'-patterns)
    }
