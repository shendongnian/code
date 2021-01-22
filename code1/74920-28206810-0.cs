    List<T> firstList;
    List<T2> toBeRemovedItems;
    List<T> finalList;
    
    foreach(T item in firstList)
    {
        toBeRemovedItems = CheckIfWeRemoveThisOne(item.Number, item.Id);
        if (toBeRemovedItems == null && toBeRemovedItems.Count() == 0)
            finalList.Add(item);
    }
