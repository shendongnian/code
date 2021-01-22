    static void Main(string[] args)
    {
        var el = XElement.Load("ConsoleApplication18.XML");
        // obviously, improve this if necessary (might not work like this if DLL isn't already loaded)
        // you can use file paths
        var assemblyName = el.Descendants("assembly").FirstOrDefault();
        var assembly = Assembly.ReflectionOnlyLoad(assemblyName.Value);
        var stringSet = new XmlDocumentationStringSet(assembly);
        foreach (var member in el.Descendants("member").ToList()) // .ToList enables removing while traversing
        {
            var attr = member.Attribute("name");
            if (attr == null)
            {
                continue;
            }
            if (!stringSet.Contains(attr.Value))
            {
                member.Remove();
            }
        }
        el.Save("ConsoleApplication18-public.XML");
    }
