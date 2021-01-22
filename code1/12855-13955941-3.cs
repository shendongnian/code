    public static string TranslateExceptionMessage(Exception E, CultureInfo targetCulture)
    {
        try
        {
            Assembly a = E.GetType().Assembly;
            ResourceManager rm = new ResourceManager(a.GetName().Name, a);
            ResourceSet rsOriginal = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true);
            ResourceSet rsTranslatet = rm.GetResourceSet(targetCulture, true, true);
            foreach (DictionaryEntry item in rsOriginal)
                if (item.Value.ToString() == E.Message.ToString())
                    return rsTranslatet.GetString(item.Key.ToString(), false); // success
        }
        catch { }
        return E.Message; // failed (error or cause it's not intelligent enough to locate '{0}'-patterns
    }
