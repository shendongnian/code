    if (Categories != null)
    {
        foreach (var usableCat in Category.LoadForProject(project.ID))
        {
           if (!Categories.Any(row => usableCat.ID == row.ID))
                Category.Load(usableCat.ID).Delete(Services.UserServices.User);
        }
    }
    if (Priorities != null)
    {
        foreach (var usablePri in Priority.LoadForProject(project.ID))
        {
            if (!Priorities.Any(row => usablePri.ID == row.ID))
                Priority.Load(usablePri.ID).Delete(Services.UserServices.User);
        }
    }
