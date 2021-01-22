    System.Reflection.Assembly resourceAssembly = System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("YourAssemblyName"));
    String[] manifests = resourceAssembly.GetManifestResourceNames(); 
    using (ResourceReader reader = new ResourceReader(resourceAssembly.GetManifestResourceStream(manifests[0])))
    {
       System.Collections.IDictionaryEnumerator dict = reader.GetEnumerator();
       while (dict.MoveNext())
       {
          String key = dict.Key as String;
          String value = dict.Value as String;
       }
    }
