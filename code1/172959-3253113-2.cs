    void DeleteUsables(dynamic usablesResource, dynamic usablesCatalog)
    {
        bool flag = false;
        foreach (dynamic usableCat in usablesCatalog.LoadForProject(project.ID))
        {
            foreach (dynamic catRow in usablesResource)
            {
                if (usableCat.ID == catRow.ID)
                    flag = true;                            
            }
            if (!flag)
            {
                int id = usableCat.ID;
                dynamic resolution = usablesCatalog.Load(id);
                resolution.Delete(Services.UserServices.User);
            }
        }
    }
