    private void LoadGroup(string option)
    {
            switch (option.ToUpper())
            {
                    case "ALPHA":
                            BindData("alphaGroup", uxAlphaGrid, FetchInformation(ManagerContext.Current.Group1));
                            break;
                    case "BRAVO":
                            BindData("bravoGroup", uxBravoGrid, FetchInformation(ManagerContext.Current.Group2));
                            break;
                    case "CHARLIE":
                            BindData("charlieGroup", uxCharlieGrid, FetchInformation(ManagerContext.Current.Group3));
                            break;
                    case "DELTA":
                            BindData("deltaTeam", uxDeltaGrid, FetchInformation(ManagerContext.Current.Group4));                        
                            break;
                    default:                                
                            break;
            }
    }
    private void BindData(string sessionName, GridView grid, VList<T> data) // I'm assuming GridView here; dunno the type, but it looks like they're shared
    {
        if (Session[sessionName] != null)
        {
                List<T> tempList = (List<T>)Session[sessionName];
                data.AddRange(tempList);
        }
        grid.DataSource = data;
        grid.DataBind();
    
    }
