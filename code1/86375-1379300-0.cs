    string commandText;
    Assembly thisAssembly = Assembly.GetExecutingAssembly();
    using (Stream s = thisAssembly.GetManifestResourceStream(
          "{project default namespace}.{path in project}.{filename}.sql"))
    {
       using (StreamReader sr = new StreamReader(s))
       {
          commandText = sr.ReadToEnd();
       }
    }
