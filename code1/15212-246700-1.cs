    private static string GetFullName()
        {
            try
            {
                DirectoryEntry de = new DirectoryEntry("WinNT://" + Environment.UserDomainName + "/" + Environment.UserName);
                return de.Properties["displayName"].Value.ToString();
            }
            catch { return null; }
        }
