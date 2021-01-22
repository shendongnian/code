    Assembly assembly = Assembly.GetExecutingAssembly();
    TextReader textReader = new StreamReader(assembly.GetManifestResourceStream(String.Format("{0}.{1}", "NameSpace.Of.File", "customConfig.xml")));
    XDocument doc = XDocument.Load(textReader);
    
    foreach (XElement element in doc.Root.Nodes())
    {
        // do stuff
    }
