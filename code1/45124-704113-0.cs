    Assembly a = Assembly.GetExecutingAssembly();
    if(a != null)
    {
      Stream s = a.GetManifestResourceStream(typeof(yourType), "YourXmlName.xml");
    
      if (s != null)
      {
        String xmlContents = new StreamReader(s).ReadToEnd();
      }
    }
