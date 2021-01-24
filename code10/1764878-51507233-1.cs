    public static bool CheckIfSolutionFolderExists(ProjectItems projectItems, string foldername)
    {
        foreach(var projectItem in projectItems)
        {
            if(projectItem.Kind == EnvDTE.vsProjectItemKindVirtualFolder)
            {
                if(projectItem.Name == foldername)
                {
                    return true;
                }
            }
        }
        return false;
    }
