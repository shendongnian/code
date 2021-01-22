    var iter = websitePages.GetEnumerator();
    iter.MoveNext();
    //Do stuff with the first element
    do {
        var websitePage = iter.Current;
        //For each element (including the first)...
    } while (iter.MoveNext());
