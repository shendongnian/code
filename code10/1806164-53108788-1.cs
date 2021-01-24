    var predicate = PredicateBuilder.False<YourType>();
    foreach (var item in items)
    {
        var innerpred = PredicateBuilder.True<YourType>();
        innerpred = innerpred.And(x=> x.A == item.A);
        innerpred = innerpred.And(x=> x.B == item.B);
        predicate = predicate.Or(innerpred);
    }
