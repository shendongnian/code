    public void ConditionallyRemoveItems(Func<Item,bool> predicate)
    {
        for (int s=0; s < itemsList.Count; s++) {
            if (predicate(itemList[s])) {
                RemoveItem(orderItemsSavedList[s].Id);
                itemList.RemoveAt(s);
                s--;
            }
        }
     }
     // ...
     ConditionallyRemoveItems(i => !i.ItemIsOnSize || !PricingOptionIsValid(i));
