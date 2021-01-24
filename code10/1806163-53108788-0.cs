    var predicate = Predicatebuilder.False<YourType>();
    foreach (var item in items)
    {
        var innerpred = Predicatebuilder.True<YourType>();
        innerpred = innerpred.And(x=> x.A = item.A);
        innerpred = innerpred.And(x=> x.B = item.B);
        predicate = predicate.Or(innerpred);
    }
