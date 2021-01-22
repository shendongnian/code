    public static void RefreshAllDropdownlists(params DropDownList[] dropDownLists)
    {
        foreach (DropDownList ddl in dropDownLists)
        {
            ddl.ClearSelection();
        }
    }
