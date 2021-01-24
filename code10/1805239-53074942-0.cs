    using Buildalyzer;
    private static IList<string> InlcudedProjectKeys = new[] { "None", "Compile", "Content", "EmbeddedResource" };
    private static IEnumerable<string> EnumerateProjectFiles(string projectPath)
    {
        AnalyzerManager manager = new AnalyzerManager();
        ProjectAnalyzer analyzer = manager.GetProject(projectPath);
        AnalyzerResults results = analyzer.Build();
        AnalyzerResult result = results.Single();
        // If only interested in C# files, check out:
        //string[] sourceFiles = result.SourceFiles;
        IReadOnlyDictionary<string, ProjectItem[]> items = result.Items;
        foreach (var item in items)
        {
            // Skip keys like ProjectReference that aren't for files
            if (!InlcudedProjectKeys.Contains(item.Key))
                continue;
            ProjectItem[] projectItems = item.Value;
            foreach (var projectItem in projectItems)
            {
                // The item spec for files will be the path relative to the project directory
                yield return projectItem.ItemSpec;
            }
        }
    }
