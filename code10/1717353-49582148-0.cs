    IQueryable<Foo> query = _context.Foo
        .Where(f => (Convert.ToDateTime(f.date1) - today).TotalDays < 31);
    if (some logic) {
        query = query.Where(f => f.recordid == x);
    }
    if (some different logic) { 
        query = query.Where(f => !StatusExceptionList.Contains(r.Status));
    }
    if (some ordering logic 1) {
        query = query.OrderBy(f => f.date1);
    }
    if (some ordering logic 2) {
        query = ((IOrderedQueryable<Foo>)query).ThenBy(f => f.date2);
    }
    if (some ordering logic 3) {
        query = ((IOrderedQueryable<Foo>)query).ThenBy(f => f.recordid);
    }
