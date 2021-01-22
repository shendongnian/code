    List<Item> itemsToRemove = new List<Items>();
    foreach (Item i in itemList) {
        if (predicate(i)) {
            itemsToRemove.Add(i);
        }
    }
    foreach (Item i in itemsToRemove)
        itemList.Remove(i);
