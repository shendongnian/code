        // At startup.
        ResourceManager mgr = Resources.ResourceManager;
        List<string> keys = new List<string>();
        ResourceSet set = mgr.GetResourceSet(CultureInfo.CurrentCulture, true, true);
        foreach (DictionaryEntry o in set)
        {
            keys.Add((string)o.Key);
        }
        mgr.ReleaseAllResources();
        Console.WriteLine(Resources.A);
