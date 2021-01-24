    string longName = "System.Collections, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
    Assembly assemCollec = Assembly.Load(longName);
    MetadataReference[] references = new MetadataReference[]
    {
        MetadataReference.CreateFromFile(assemCollec.Location),
        // Other Assemblies . . .
    
    };
