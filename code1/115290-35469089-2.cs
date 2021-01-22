cs
      internal static System.Reflection.Assembly CurrentDomain_ResourceResolve(object sender, ResolveEventArgs args)
            {
                try
                {
                    if (args.Name.StartsWith("your.resource.namespace"))
                    {
                        return LoadResourcesAssyFromResource(System.Threading.Thread.CurrentThread.CurrentUICulture, "name of your the resource that contains dll");
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
3) Now you have to implement LoadResourceAssyFromResource something like
 
cs
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
