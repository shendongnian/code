    private void LoadGroup(string option)
    {
            switch (option.ToUpper())
            {
                    case "ALPHA":
                            BindGroup(ManagerContext.Current.Group1, "alphaGroup", uxAlphaGrid);
                            break;
                    case "BRAVO":
                            BindGroup(ManagerContext.Current.Group2, "bravoGroup", uxBravoGrid);
                            break;
                    case "CHARLIE":
                            BindGroup(ManagerContext.Current.Group3, "charlieGroup", uxCharlieGrid);
                            break;
                    case "DELTA":
                            BindGroup(ManagerContext.Current.Group4, "deltaGroup", uxDeltaGrid);
                            break;
                    default:                                
                            break;
            }
    }
    
    private void BindGroup(GroupType group, string groupName, GridView grid)
    {
        VList<T> vList = FetchInformation(group);
    
        if (Session[groupName] != null)
        {
            List<T> tempList = (List<T>)Session[groupName];
            vList.AddRange(tempList);
        }
        grid.DataSource = vList;
        grid.DataBind();
    }
