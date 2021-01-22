    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        try
        {
            string location = assembly.Location;
            if (!String.IsNullOrEmpty(location))
            {
                cp.ReferencedAssemblies.Add(location);
            }
        }
        catch (NotSupportedException)
        {
            // this happens for dynamic assemblies, so just ignore it.
        }
    }
