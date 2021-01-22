    var removeList = new List<decimal>();
    foreach (var item in myDictionary)
    {
        // have a condition which indicates which items are to be removed
        if (item.Key > 1)
        {
            removeList.Add(item.Key);
        }
    }
    // remove from the main collection
    foreach (var key in removeList)
    {
        myDictionary.Remove(key);
    }
