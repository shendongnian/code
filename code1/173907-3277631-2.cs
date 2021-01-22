     public static class DropDownListExtensions
        {
            public static void Reset(this DropDownList dropDownList)
            {
                dropDownList.ClearSelection();
                //... do more stuff
                    
            }
        }
    
    listsToRefresh.ForEach(l=>l.Reset());
