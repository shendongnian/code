    var index = cas.BinarySearch(new Record { Datetime = min }, new RecordDateComparer());
    if (index < 0)
        index = ~index;
    var possibleResults = new List<Record>();    
    // go backwards, for duplicates            
    for (int i = index - 1; i >= 0; i--) {
        var res = cas[i];
        if (res.Datetime <= max && res.Datetime >= min)
            possibleResults.Add(res);
        else break;
    }
    // go forward until item bigger than max is found
    for (int i = index; i < cas.Count; i++) {
        var res = cas[i];
        if (res.Datetime <= max &&res.Datetime >= min)
            possibleResults.Add(res);
        else break;
    }    
            
