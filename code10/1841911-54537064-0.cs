    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Windows";
            Console.WriteLine($"{path} - {getRights(path)}");
            Console.ReadLine();
        }
        static string getRights(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return "Directory doesn't exist";
            }
            FileSystemRights fsRights = 0;
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            AuthorizationRuleCollection authRules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(currentUser);
            foreach (AuthorizationRule rule in authRules)
            {
                FileSystemAccessRule fsRule = rule as FileSystemAccessRule;
                if (fsRule != null)
                {
                    NTAccount ntAccount = rule.IdentityReference as NTAccount;
                    if (principal.IsInRole(ntAccount.Value))
                    {
                        if (fsRule.FileSystemRights > fsRights)
                        {
                            fsRights = fsRule.FileSystemRights;
                        }
                    }
                }
            }
            switch (fsRights)
            {
                case FileSystemRights.FullControl:
                    return "Full Control";
                case FileSystemRights r when (r >= FileSystemRights.Write):
                    return "Write";
                case FileSystemRights r when (r >= FileSystemRights.ReadData):
                    return "Read";
                default:
                    return "No rights";
            }
        }
    }
