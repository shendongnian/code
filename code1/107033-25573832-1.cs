    public static string GetTestDataFolder(string testDataFolder)
    {
        string startupPath = ApplicationEnvironment.ApplicationBasePath;
        var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
        var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
        string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
        return Path.Combine(projectPath, "Data", testDataFolder);
    }
