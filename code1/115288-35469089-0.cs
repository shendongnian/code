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
