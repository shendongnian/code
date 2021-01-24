    if (!IsPostBack)
    {
        if (ddlYearForProject.Items.Count == 0)
                {
                    ddlYearForProject.Items.Insert(0, new ListItem(DateTime.Today.AddYears(-3).Year.ToString(), string.Empty));
                    ddlYearForProject.Items.Insert(0, new ListItem(DateTime.Today.AddYears(-2).Year.ToString(), string.Empty));
                    ddlYearForProject.Items.Insert(0, new ListItem(DateTime.Today.AddYears(-1).Year.ToString(), string.Empty));
                    ddlYearForProject.Items.Insert(0, new ListItem(DateTime.Today.Year.ToString(), string.Empty));
                }
    }
