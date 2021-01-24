    var books = myContext.Books.Include(nameof(Book.authors))
       .Select(b => new { 
          b.Name, 
          b.Content, 
          AuthorNames = b.authors.Select(a => a.Name) 
       })
       .ToList()
       .Select(b => new {
          b.Name,
          b.Content,
          Authors = string.Join(", ", b.AuthorNames)
       });
