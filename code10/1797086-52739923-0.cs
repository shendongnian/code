    var predicate = PredicateBuilder.True<SomeClass>();
    if (SomeCondition)
    {
         var inner = PredicateBuilder.False<SomeClass>();
             inner = inner.Or(p => p.Category == "WhatEver");
             inner = inner.Or(p => p.Category == "");
         predicate = predicate.And(inner);
    }
    ...
    var result = MyIEnumerable<SomeClass>.AsQueryable()
                                         .Where(predicate)
                                         .FirstOrDefault();
