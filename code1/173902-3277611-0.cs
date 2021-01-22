    public static void RefreshAllDropdownlists(List<DropDownList> lists)
    {
       foreach(DropDownList dropDown in lists)
       {
         dropDown.ClearSelection();
       }
    }
