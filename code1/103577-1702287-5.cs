    foreach (string pageItemIdCode in pageItemsIdCodes)
    {
       Type t = Type.GetTypeFromProgID(pageItemIdCode);
       BasePageItem pageItem = (BasePageItem)Activator.CreateInstance(t, new object[]{this});
       PageItemRecords.Add(pageItemIdCode, pageItem);
    }
