    public static void PrintProjects(string solutionPath)
    {
    	var slnFile = SolutionFileParser.ParseFile(FileSystemPath.Parse(solutionPath));
    	foreach (var project in slnFile.Projects)
    	{
    		Console.WriteLine(project.ProjectName);
    		Console.WriteLine(project.ProjectGuid);
    		Console.WriteLine(project.ProjectTypeGuid);
    		foreach (var kvp in project.ProjectSections)
    		{
    			Console.WriteLine(kvp.Key);
    			foreach (var projectSection in kvp.Value) 
    			{
    				Console.WriteLine(projectSection.SectionName);
    				Console.WriteLine(projectSection.SectionValue);
    				foreach (var kvpp in projectSection.Properties)
    				{
    					Console.WriteLine(kvpp.Key); 
    					Console.WriteLine(string.Join(",", kvpp.Value));
    				}
    			}
    		}
    	}
    }
