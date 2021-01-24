    ProjectItem item;
    if(Directory.Exists(itemname))
    {
        item = project.AddFromDirectory(itemname);
    }
    else
    {
        item = project.AddFolder(itemname);
    }
