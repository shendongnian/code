    public string GetPath(string basefolder, string[] extraFolders)
    {
        string version = Versioner.GetBuildAndDotNetVersions();
        string callingModule = StackCrawler.GetCallingModuleName();
        List<string> parameters = new List<string>(extraFolders.Length + 3);
        parameters.Add(basefolder);
        parameters.Add(version);
        parameters.Add(callingModule);
        parameters.AddRange(extraFolders);
        return AppendFolders(parameters.ToArray());
    }
