    void SaveChanges()
    {
        // your CsvFile database has functions to add / update / remove items
        foreach (var itemToAdd in itemsToAdd)
        {
            csvDatabase.Add(itemToAdd);
        }
        
        // update or remove fetched items with OriginalValue unequal to Value
        var itemsToUpdate = this.fetchedItems
            .Where(fetchedItem => !ValueComparer.Equals(fetchedItem.OriginalValue, fetchedItem.Value)
            .ToList();
        foreach (Entity<T> itemToUpdate in itemsToUpdate)
        {
            if (itemToUpdate.Value == null)
            {   // remove
                csvFile.Remove(itemToUpdate.OriginalValue);
            }
            else
            {   // update
                csvFile.Update(...);
            } 
        }
    }
