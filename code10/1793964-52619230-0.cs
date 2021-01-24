    var bookQueryable = _db.Books.AsQueryable();
    switch (currentUser.Role)
    {
         case "Admin": break;
         case "Publisher": bookQueryable = bookQueryable.Where(x => x.Publisher == currentUser.PublisherId);
         default: throw new UnauthorizedAccessException(); // Given role is not authorized.
    } 
    var query = (
    from b in bookQueryable
    join a in _db.Authors on b.AuthorId equals a.Id
    select new BookViewModel
    {
       AuthorName = a.Name,
       BookName = b.Name
    });
    
    return query.ToList();
