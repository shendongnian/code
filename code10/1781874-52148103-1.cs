    // if both are null, return an object with all bools as false
    if (list1 == null && list2 == null)
        return new RrmModulePermission();
    // if list1 is null, set all bools to false
    if (list1 == null)
        list1 = new RrmModulePermission();
    // if list2 is null, set all bools to false
    if (list2 == null)
        list2 = new RrmModulePermission();
    var list3 = new RrmModulePermission
    {
        View = list1.View || list2.View,
        ViewAll = list1.ViewAll || list2.ViewAll,
        Add = list1.Add || list2.Add,
        Edit = list1.Edit || list2.Edit,
        Delete = list1.Delete || list2.Delete,
        Import = list1.Import || list2.Import,
        Export = list1.Export || list2.Export
    };
    return list3;
