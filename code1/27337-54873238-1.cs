    Assembly myAssembly = Assembly.GetExecutingAssembly();
    string[] names = myAssembly.GetManifestResourceNames();
    foreach (string name in names)
    {
       Console.WriteLine( name );
    } 
