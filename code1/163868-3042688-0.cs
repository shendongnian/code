    public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
    {
        if (automationObject is DTE)
        {
            DTE dte = (DTE)automationObject;
            Array activeProjects = (Array)dte.ActiveSolutionProjects;
        
            if (activeProjects.Length > 0)
            {
                Project activeProj = (Project)activeProjects.GetValue(0);
                    
                foreach (ProjectItem pi in activeProj.ProjectItems)
                {
                    // Do something for the project items like filename checks etc.
                }
            }
        }
    }
