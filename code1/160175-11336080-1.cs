    // This predicate is the 1st predicate builder
    var predicate = PredicateBuilder.True<Widget>();
    // and I am adding more predicates to it (all no problem here)
    predicate = predicate.And(c => c.ColumnA == 1);
    predicate = predicate.And(c => c.ColumnB > 32);
    predicate = predicate.And(c => c.ColumnC == 73);
    // Now I want to add another "AND" predicate which actually comprises 
    // of a whole list of sub-"OR" predicates
    if(keywords.Length > 0)
    {
        // NOTICE: Here I am starting off a brand new 2nd predicate builder....
        // (I'm not "AND"ing it to the existing one (yet))
        var subpredicate = PredicateBuilder.False<Widget>();
        foreach(string s in keywords)
        {
            string t = s;  // s is part of enumerable so need to make a copy of it
            subpredicate = subpredicate.Or(c => c.Name.Contains(t));
        }
        // This is the "gotcha" bit... ANDing the independent
        // sub-predicate to the 1st one....
        // If done like this, you will FAIL!
    //  predicate = predicate.And(subpredicate); // FAIL at runtime!
        // To correct it, you must do this...
        predicate = predicate.And(subpredicate.Expand());  // OK at runtime!
    }
