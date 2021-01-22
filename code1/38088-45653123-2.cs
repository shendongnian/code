    private void Test_Interpollation()
    {
        string ConfigPath = ConfigurationManager.AppSettings["InterpollationExample"];
        string SolutionPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
        string ExpandedPath = string.Format(ConfigPath, SolutionPath.ToString());
        Console.WriteLine($"Using old interpollation {ExpandedPath}");
    }
