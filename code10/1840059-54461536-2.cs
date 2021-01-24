    foreach (var joinedItem in joinResult)
    {
        if (joinedItem.OldItem == null)
        {
            // we won't have both items null, so we know NewItem is not null
            AddItem(joinedItem.NewItem);
        }
        else if (joinedItem.NewItem == null)
        {   // old not null, new equals null
            DeleteItem(joinedItem.OldItem);
        }
        else
        {  // both old and new not null, if desired: check if update needed
            if (!comparer.Equals(old, new))
            {   // changed
                UpdateItems(old, new)
            }
        }
    }
