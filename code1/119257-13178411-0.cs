    /// <summary>
    /// Sets or replaces the ResourceDictionary by dynamically loading
    /// a Localization ResourceDictionary from the file path passed in.
    /// </summary>
    /// <param name="resourceDictionaryFile">The resource dictionary to use to set/replace
    /// the ResourceDictionary.</param>
    private void SetCultureResourceDictionary(String resourceDictionaryFile)
    {
        // Scan all resource dictionaries and remove, if it is string resource distionary
        for ( int index= 0; index < Resources.MergedDictionaries.Count; ++index)
        {
            // Look for an indicator in the resource file that indicates that this
            // is a dynamic file that should be removed before loading its replacement.
            if (Resources.MergedDictionaries[index].Contains("ResourceDictionaryName"))
            {
                if ( File.Exists(resourceDictionaryFile) )
                {
                    Resources.MergedDictionaries.Remove(Resources.MergedDictionaries[index]);
                }
            }
        }
    
        // read required resource file to resource dictionary and add to MergedDictionaries collection
        ResourceDictionary newResourceDictionary =  new ResourceDictionary();
        newResourceDictionary.Source = new Uri(resourceDictionaryFile);
        Resources.MergedDictionaries.Add(newResourceDictionary);
    }
