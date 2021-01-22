      // Using the source code cache...
      // gets the active Solution object
      SolutionElement activeSolution = CodeRush.Source.ActiveSolution;
      if (activeSolution == null)
        return;
      // iterate thought all projects in the solution
      foreach (ProjectElement project in activeSolution.AllProjects)
      {
        string assemblyName = project.AssemblyName;
	    // iterate inside source code symbols cache...
        Hashtable projectSymbols = activeProject.ProjectSymbols;
        foreach (object item in projectSymbols.Values)
        {
          ITypeElement typeElement = item as ITypeElement;
          if (typeElement == null)
            continue;
          // TODO: ...
        }
      }
