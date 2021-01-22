    private static string TranslateExceptionMessage(Exception E, CultureInfo TargetCulture)
    {
        Assembly a = E.GetType().Assembly;
        ResourceManager rm = new ResourceManager(a.GetName().Name, a);
        ResourceSet rsOriginal = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true);
        ResourceSet rsTranslatet = rm.GetResourceSet(TargetCulture, true, true);
        foreach (DictionaryEntry item in rsOriginal)
            if (item.Value.ToString() == E.Message.ToString())
                return rsTranslatet.GetString(item.Key.ToString(), false); // success
        return E.Message; // failed (cause it's not intelligent enough to locate '{0}'-patterns
    }
