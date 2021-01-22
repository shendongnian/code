	internal static Project GetActiveProject()
	{
		DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
		return GetActiveProject(dte);
	}
	internal static Project GetActiveProject(DTE dte)
	{
		Project activeProject = null;
		Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
		if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
		{
			activeProject = activeSolutionProjects.GetValue(0) as Project;
		}
		return activeProject;
	}
