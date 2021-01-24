    var query = (
        from b in _db.Books
        join a in _db.Authors on b.AuthorId = a.Id
        select new BookViewModel
        {
           AuthorName = a.Name,
           BookName = b.Name
        });
    
    if (currentUser.Role.Equals("Admin")
    {
        query = query.Where(x => x.Publisher == currentUser.PublisherId);
    }
    return query.ToList();
