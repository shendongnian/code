    Assembly a = typeof(Assembly.Namespace.Class).Assembly;
    Stream s = a.GetManifestResourceStream("Assembly.Namespace.Path.To.File.xml");
    XmlDocument mappingFile = new XmlDocument();
    mappingFile.Load(s);
    s.Close();
