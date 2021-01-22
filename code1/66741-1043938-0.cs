    using System.Management;
    ...
    string ancestor = "WMIEvent";     // the ancestor class
    string scope = "root\\wmi";       // the WMI namespace to search within
    try
    {
        EnumerationOptions options = new EnumerationOptions();
        options.ReturnImmediately = true;
        options.Rewindable = false;
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher(scope, "SELECT * FROM meta_class", options);
        foreach (ManagementClass cls in searcher.Get())
        {
            if (cls.Derivation.Contains(ancestor))
            {
                Console.WriteLine(cls["__CLASS"].ToString());
            }
        }
    }
    catch (ManagementException exception)
    {
        Console.WriteLine(exception.Message);
    }
