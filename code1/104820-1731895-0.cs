    class Program
    {
        static void Main(string[] args)
        {
            var iis = new DirectoryEntry("IIS://localhost/W3SVC");
            var sites = (from DirectoryEntry entry in iis.Children
                         where entry.SchemaClassName == "IIsWebServer"
                         select entry).ToArray();
            foreach (var site in sites)
            {
                Console.WriteLine(site.Name);
            }
        }
