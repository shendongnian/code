    // To simulate a database table of user names
    private static readonly List<string> DbUserNames = new List<string>();
    // Mock method to get existing users from database
    private static List<string> GetUserNamesFromDb()
    {
        return DbUserNames;
    }
    // Default prefix for invalid user names
    private const string DefaultPrefix = "user_";
    /// <summary>
    /// Gets a default user name based on the name
    /// </summary>
    /// <param name="name">The user's real name</param>
    /// <returns>Default user name for this name</returns>
    private static string GetDefaultUserName(string name)
    {
        var defaultName = name?.Trim() ?? string.Empty;
        if (defaultName == string.Empty)
        {
            defaultName = DefaultPrefix;
        }
        else
        {
            var spaceIndex = defaultName.IndexOf(' ');
            if (spaceIndex > -1)
                defaultName =
                    defaultName[0] + defaultName.Substring(spaceIndex + 1);
        }
        var existingUserNames = GetUserNamesFromDb();
        var duplicateNameCount = existingUserNames.Count(userName =>
            userName.StartsWith(defaultName) &&
            userName.Skip(defaultName.Length).All(char.IsNumber));
        if (duplicateNameCount > 0) defaultName += duplicateNameCount + 1;
        if (defaultName == DefaultPrefix) defaultName += "1";
        // Add this to our list so we can simulate tracking existing users
        DbUserNames.Add(defaultName);
        return defaultName.ToLower();
    }
