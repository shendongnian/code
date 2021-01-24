    var query =
        from b in _db.Books
        join a in _db.Authors on b.AuthorId = a.Id
        select new { a, b };
    // We'll test just the role that needs additional filtering.  Here,
    // 'x' is the aforementioned opaque identifier.
    if (currentUser.Role == "Publisher")
        query = query.Where(x => x.b.PublisherId == currentUser.PublisherId);
