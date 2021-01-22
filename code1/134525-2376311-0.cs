    IEnumerable<X> query = items;
    if (a.HasValue) {
        query = query.Where(x => x.a == a.Value)
    }
    if (b.HasValue) {
        query = query.Where(x => x.b == b.Value)
    }
    if (c.HasValue) {
        query = query.Where(x => x.c == c.Value)
    }
