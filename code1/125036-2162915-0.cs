    public void Filter(List<Item> searchResults)
    {
        searchResults = (from item1 in searchResults
                         join item2 in coll
                         on item1.skuID equals item2.Skuid
                         where item2.SearchableValue == value
                         select item1).ToList();
    }
    ...
    list = ...
    Filter(list);
