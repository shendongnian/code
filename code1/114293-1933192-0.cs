    using System.Management;
    ...
    try
    {
        EnumerationOptions options = new EnumerationOptions();
        options.ReturnImmediately = true;
        options.Rewindable = false;
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Meta_Class", options);
        ManagementObjectCollection classes = searcher.Get();
        foreach (ManagementClass cls in classes)
        {
            Console.WriteLine(cls.ClassPath.ClassName);
        }
    }
    catch (ManagementException exception)
    {
        Console.WriteLine(exception.Message);
    }
