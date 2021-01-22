    var qry = from ....
    if(asc) {
        qry = qry.OrderBy(x=>x.SomeSortField);
    } else {
        qry = qry.OrderByDescending(x=>x.SomeSortField);
    }
