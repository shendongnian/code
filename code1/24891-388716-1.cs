    var qry = from .... // or just dataList.AsEnumerable()/AsQueryable()
    if(sortAscending) {
        qry = qry.OrderBy(x=>x.Property);
    } else {
        qry = qry.OrderByDescending(x=>x.Property);
    }
