    class SearchItem
    {
       string Name {get; set;}
       bool IsSelected {get; set;}
    }
    class FoodSearchCriteria
    {
       String searchText {get; set;}
       IList<SearchItem> SearchItems{ get; }
    }
    public IList<FoodItem> FindFoodItems(FoodSearchCriteria criteria)
    // in reality, this is a fuzzy search not an exact match
    var matches = _DB.FoodItems.Where(x => x.FoodTitle == criteria.SearchText && 
                                          criteria.SearchItems.Where(si => si.IsSelected).Contains(i => i.Name == x.Type));
    
    return mathces;
    }
