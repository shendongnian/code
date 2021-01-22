    private void LoadGroup(string option)
    {
        option = option.ToLower();
        sessionContent = Session[option + "Group"];
        switch(option)
        {
            case "alpha":
                var grp = ManagerContext.Current.Group1;
                var grid = uxAlphaGrid;
                break;
            case "bravo":
                var grp = ManagerContext.Current.Group2;
                var grid = uxBravoGrid;
                break;
            case "charlie":
                var grp = ManagerContext.Current.Group3;
                var grid = uxCharlieGrid;
                break;
            // Add more cases if necessary
            default:
                throw new ArgumentException("option", "Non-allowed value");
        }
        VList<T> groupList = FetchInformation(grp);
        if (sessionContent != null)
        {
            List<T> tempList = (List<T>)sessionContent;
            groupList.AddRange(tempList);
        }
        
        grid.DataSource = List("alpha";
        grid.DataBind();
    }
