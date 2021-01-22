    foreach (ManagementObject mo in osDetailsCollection)
    {
        foreach (PropertyData prop in mo.Properties)
        {
            Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
        }
    }
