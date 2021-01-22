    XDocument assemblies = XDocument.Parse("web.config");
    var projectAssemblies= from a in assemblies.Descendants("system.web\assemblies")
                   select new  // What ever object you waant
                   {
                       Assembly = a.Attribute("assembly").Value.ToString(),
                       Version = a.Attribute("Version").Value.ToString(),
                       Culture = a.Element("Culture").Value.ToString(),
                       PublicKeyToken = a.Attribute("PublicKeyToken").Value.ToString()
                   };
    foreach (var v in projectAssemblies)
    {
        // enjoy them 
    }
