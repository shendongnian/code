    foreach (string pageItemIdCode in pageItemsIdCodes)
    {
       Type t = Type.GetTypeFromProgID(pageItemIdCode);
       Object pageItem = Activator.CreateInstance(t, new object[]{this});
       PageItemRecords.Add(pageItemIdCode, pageItem);
    }
