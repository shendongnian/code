    Assembly asm = Assembly.GetExecutingAssembly();
    Stream resourceStream = asm.GetManifestResourceStream("MagicBeans");
    
    dictionary = new Dictionary<string, object>();
    using (ResourceReader r = new ResourceReader(resourceStream))
    {
        foreach(DictionaryEntry entry in r.OfType<DictionaryEntry>())
        {
           dictionary.Add(entry.Key.ToString(), entry.Value);
        }
    }
