    private void LoadGroup(string option)
    {
            switch (option.ToUpper())
            {
                    case "ALPHA":
                            BindGroup(ManagerContext.Current.Group1, "alphaGroup");
                            break;
                    case "BRAVO":
                            BindGroup(ManagerContext.Current.Group2, "bravoGroup");
                            break;
                    case "CHARLIE":
                            BindGroup(ManagerContext.Current.Group3, "charlieGroup");
                            break;
                    case "DELTA":
                            BindGroup(ManagerContext.Current.Group4, "deltaGroup");
                            break;
                    default:                                
                            break;
            }
    }
    
    private void BindGroup(GroupType group, string groupName)
    {
        VList<T> vList = FetchInformation(group);
    
        if (Session[groupName] != null)
        {
            List<T> tempList = (List<T>)Session[groupName];
            vList.AddRange(tempList);
        }
        uxAlphaGrid.DataSource = vList;
        uxAlphaGrid.DataBind();
    }
