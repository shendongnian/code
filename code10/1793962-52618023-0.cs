    var query = (
        from b in _db.Books
        join a in _db.Authors on b.AuthorId = a.Id
    	Where (b.Publisher == currentUser.PublisherId && currentUser.Role == "Publisher") ||
    	      (currentUser.Role == "Admin")
        select new BookViewModel
        {
           AuthorName = a.Name,
           BookName = b.Name
        });
