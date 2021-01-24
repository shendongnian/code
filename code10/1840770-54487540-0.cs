using System;
using System.Management;
...
void ListNetworkAdapters()
{
    var query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
    using (var searcher = new ManagementObjectSearcher(query))
    {
        var queryCollection = searcher.Get();
        foreach (var m in queryCollection)
        {
            Console.WriteLine("ServiceName : {0}", m["Name"]);
            Console.WriteLine("MACAddress : {0}", m["Description"]);
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
The documentation can be found here:
https://docs.microsoft.com/en-us/windows/desktop/cimwin32prov/win32-networkadapter
