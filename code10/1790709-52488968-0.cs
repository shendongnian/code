		IEnumerable<string> Assemblies => Projects
			.SelectMany(GetProjectAndSubProjects) // ################# Flatten the list of projects
            .Select(p => p?.Properties?.Item("AssemblyName")?.Value as string)
            .Distinct()
			.Where(a => !string.IsNullOrWhiteSpace(a));
        IEnumerable<Project> Projects => VisualStudio.Solution.Projects.OfType<Project>();
        private static IEnumerable<EnvDTE.Project> GetProjectAndSubProjects(EnvDTE.Project project)
        {
            if (project.Kind == VsProjectKindSolutionFolder)
            {
                return project.ProjectItems
                    .OfType<EnvDTE.ProjectItem>()
                    .Select(p => p.SubProject)
                    .Where(p => p != null)
                    .SelectMany(GetProjectAndSubProjects);
            }
            return new[] { project };
        }
		// Copied from EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder
		private const string VsProjectKindSolutionFolder = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
