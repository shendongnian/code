    private Assembly LoadResourceAssyFromResource( Culture culture, ResourceName resName)
            {
                        //var x = Assembly.GetExecutingAssembly().GetManifestResourceNames();
    
                        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resName))
                        {
                            if (stream == null)
                            {
                                //throw new Exception("Could not find resource: " + resourceName);
                                return null;
                            }
    
                            Byte[] assemblyData = new Byte[stream.Length];
    
                            stream.Read(assemblyData, 0, assemblyData.Length);
    
                            var ass = Assembly.Load(assemblyData);
    
                            return ass;
            }
}
