    private static void WriteToHostsFile(IEnumerable<HostEntry> hostEntries, IHostsFileWriter hostsWriter)
        {
            var hostsText = hostsWriter.GetHostsFileText(hostEntries);
            var fi = new FileInfo("hoststemp.txt");
            File.WriteAllText("hoststemp.txt", hostsText);
            var defaults = Security.AuthorizationFlags.Defaults;
            using (var auth = Security.Authorization.Create(defaults))
            {
                auth.ExecuteWithPrivileges("/bin/cat", defaults, new[] { fi.FullName + " > /etc/hosts" });
            }
        }
