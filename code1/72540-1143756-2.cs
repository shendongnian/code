    PredicateBuilder predicate = PredicateBuilder.False<FoodItem>();
    if (criteria.SearchFreshFoods)
    {
        predicate = predicate.Or(x => x.Type == 'Fresh Foods');
    }
    if (criteria.SearchFrozenFoods)
    {
        predicate = predicate.Or(x => x.Type == 'Frozen Foods'));
    }
    ...
    _DB.FoodItems.Where(predicate);
