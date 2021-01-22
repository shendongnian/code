           __ changed ______        __ changed ______
    public IEnumerable<Item> Filter(IEnumerable<Item> searchResults)
    {
        return from item1 in searchResults               <-- changed
               join item2 in coll
               on item1.skuID equals item2.Skuid
               where item2.SearchableValue == value
               select item1;                             <-- changed
    }
    ...
    list = ...         _ added__
    list = Filter(list).ToList();
