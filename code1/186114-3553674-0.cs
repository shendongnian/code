    using System.Collections;
    using System.DirectoryServices;
    /// <summary>
    /// Gets the list of AD groups that a user belongs to
    /// </summary>
    /// <param name="loginName">The login name of the user (domain\login or login)</param>
    /// <returns>A comma delimited list of the user's AD groups</returns>
    public static SortedList GetADGroups(string loginName)
    {
        if (string.IsNullOrEmpty(loginName))
            throw new ArgumentException("The loginName should not be empty");
        SortedList ADGroups = new SortedList();
        int backSlash = loginName.IndexOf("\\");
        string userName = backSlash > 0 ? loginName.Substring(backSlash + 1) : loginName;
        DirectoryEntry directoryEntry = new DirectoryEntry();
        DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry, "(sAMAccountName=" + userName + ")");
        SearchResult searchResult = directorySearcher.FindOne();
        if (null != searchResult)
        {
            DirectoryEntry userADEntry = new DirectoryEntry(searchResult.Path);
            // Invoke Groups method.
            object userADGroups = userADEntry.Invoke("Groups");
            foreach (object obj in (IEnumerable)userADGroups)
            {
                // Create object for each group.
                DirectoryEntry groupDirectoryEntry = new DirectoryEntry(obj);
                string groupName = groupDirectoryEntry.Name.Replace("cn=", string.Empty);
                groupName = groupName.Replace("CN=", string.Empty);
                if (!ADGroups.ContainsKey(groupName))
                    ADGroups.Add(groupName, groupName);
            }
        }
        return ADGroups;
    }
