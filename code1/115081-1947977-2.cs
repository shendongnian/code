    function helper(grp, grpname, dg) {
        VList<T> theList = FetchInformation(grp); 
        if (Session[grpname] != null) 
        { 
            List<T> tempList = (List<T>)Session[grpname]; 
            theList.AddRange(tempList); 
        } 
        dg.DataSource = theList; 
        dg.DataBind(); 
    }
    private void LoadGroup(string option) 
    { 
            switch (option.ToUpper()) 
            { 
                    case "ALPHA": 
                            helper(ManagerContext.Current.Group1, "alphaGroup", uxAlphaGrid);
                            break; 
                    case "BRAVO": 
                            helper(ManagerContext.Current.Group2, "bravoGroup", uxBravoGrid);
                            break; 
                    case "CHARLIE": 
                            helper(ManagerContext.Current.Group3, "charlieGroup", uxCharlieGrid);
                            break; 
                    case "DELTA": 
                            helper(ManagerContext.Current.Group4, "deltaGroup", uxDeltaGridlieGrid);
                            break; 
                    default:                                 
                            break; 
            } 
    } 
