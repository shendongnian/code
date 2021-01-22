    List<string> types = new List<string>();
    if (criteria.SearchFreshFoods) { types.Add("Fresh Foods"); }
    if (criteria.SearchFrozenFoods) { types.Add("Frozen Foods"); }
    if (criteria.SearchBeverages) { types.Add("Beverages"); }
    if (criteria.SearchDeliCounter) { types.Add("Deli Counter"); }
    return _DB.FoodItems.Where(x => x.FoodTitle == SearchString &&
                                    types.Contains(x.Type));
