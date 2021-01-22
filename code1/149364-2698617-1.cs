    var removeList = new List<decimal>();
    foreach (var item in myDictionary)
    {
        // have a condition which indicates which items are to be removed
        if (item.Key > 1)
        {
            removeList.Add(item.Key);
        }
    }
