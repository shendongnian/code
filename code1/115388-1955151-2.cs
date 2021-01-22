    List<Item> itemsToKeep = new List<Items>();
    foreach (Item i in itemList) {
        if (!predicate(i)) {
            itemsToKeep.Add(i);
        }
     }
     itemList = itemsToKeep;
