    var result = myDbContext.ApplicationUsers
        .Where(user => user.BirtDate > new DateTime(2010, 1, 1)
        .Select(user => new
        {
             Id = user.Id,
             Name = user.Name,
             AuthoredOldBooks = user.Books
                 .Where(book => book.PublicationDate < new DateTime(1900, 1, 1)
                 .ToList(),
        }
