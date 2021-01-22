    using System;
    using System.IO;
    using System.DirectoryServices;
    
    class Class
    {
        static void Main(string[] args)
        {
            DirectoryEntry entry = FindVirtualDirectory("<Server>", "Default Web Site", "<WantedVirtualDir>");
            if (entry != null)
            {
                Console.WriteLine(entry.Properties["AppPoolId"].Value);
            }
        }
    
        static DirectoryEntry FindVirtualDirectory(string server, string website, string virtualdir)
        {
            DirectoryEntry siteEntry = null;
            DirectoryEntry rootEntry = null;
            try
            {
                siteEntry = FindWebSite(server, website);
                if (siteEntry == null)
                {
                    return null;
                }
    
                rootEntry = siteEntry.Children.Find("ROOT", "IIsWebVirtualDir");
                if (rootEntry == null)
                {
                    return null;
    
                }
    
                return rootEntry.Children.Find(virtualdir, "IIsWebVirtualDir");
            }
            catch (DirectoryNotFoundException ex)
            {
                return null;
            }
            finally
            {
                if (siteEntry != null) siteEntry.Dispose();
                if (rootEntry != null) rootEntry.Dispose();
            }
        }
    
        static DirectoryEntry FindWebSite(string server, string friendlyName)
        {
            string path = String.Format("IIS://{0}/W3SVC", server);
            
            using (DirectoryEntry w3svc = new DirectoryEntry(path))
            {
                foreach (DirectoryEntry entry in w3svc.Children)
                {
                    if (entry.SchemaClassName == "IIsWebServer" &&
                        entry.Properties["ServerComment"].Value.Equals(friendlyName))
                    {
                        return entry;
                    }
                }
            }
            return null;
        }
    }
