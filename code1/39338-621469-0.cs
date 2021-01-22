    var predicate = PredicateBuilder.True<MyLinqType>();
    if(!string.IsNullOrEmpty(name))
        predicate = predicate.And(p => p.name == name);
    ...
    var myResults = Context.MyLinTypeQueryTable.Where(predicate);
