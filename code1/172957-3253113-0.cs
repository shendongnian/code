    void DeleteUsables(dynamic usablesResource)
    {
        bool flag = false;
        foreach (dynamic usableCat in usablesResource.LoadForProject(project.ID))
        {
            foreach (dynamic catRow in usablesResource)
            {
                if (usableCat.ID == catRow.ID)
                    flag = true;                            
            }
            if (!flag)
            {
                int id = usableCat.ID;
                dynamic resolution = usablesResource.Load(id);
                resolution.Delete(Services.UserServices.User);
            }
        }
    }
