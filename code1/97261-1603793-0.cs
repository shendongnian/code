    public static Object MyGetGlobalResourceObject (string classKey,
                                                    string resourceKey)
    {
        try
        {
            return GetGlobalResourceObject (classKey, resourceKey);
        }
        catch (MissingManifestResourceException ex)
        {
            // log error
            return null;
        }
    }
