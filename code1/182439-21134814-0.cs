    public static string GetUserFullName(string domain, string userName)
            {
                DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
                return (string)userEntry.Properties["fullname"].Value;
            }
