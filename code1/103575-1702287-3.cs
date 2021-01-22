    foreach (string pageItemIdCode in pageItemsIdCodes)
    {
       Type t = Type.GetTypeFromProgID(pageItemIdCode);
       BasePageItem pageItem = Activator.CreateInstance(t); // Change constructor
       pageItem.SetMananger(this); // Add SetMananger call to BasePageItem
       PageItemRecords.Add(pageItemIdCode, pageItem);
    }
