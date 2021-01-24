    public Entity<T> Find(TKey primaryKey)
    {
        // is it already in the Dictionary (found before)?
        // if not: get it from the CsvDatabase and put it in the dictionary
        if (!fetchedItems.TryGetValue(primaryKey, out Entity<T> fetchedEntity))
        {
            // not fetched yet, fetch if from your Csv File
            T fetchedItem = ...
            // what to do if does not exist?
            // add to the dictionary:
            fetchedEntities.Add(new Entity<T>
            {
                value = fetchedItem,
                originalValue = (T)fetchedItem.Clone(),
                // so if value changes, original does not change
            });
        }
        return fetchedItem;
    }
