    public static bool CheckIfFileExistsInProject(ProjectItems projectItems, string fullpath)
    {
        foreach(ProjectItem projectItem in projectItems)
        {
            if(projectItem.Name == fullpath)
            {
                return true; 
            }
            else if ((projectItem.ProjectItems != null) && (projectItem.ProjectItems.Count > 0))
            {
                /* recursive search */
                return CheckIfFileExistsInProject(projectItem.ProjectItems, fullpath);
            }
        } 
        return false;
    }
