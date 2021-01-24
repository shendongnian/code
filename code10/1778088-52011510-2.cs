    var books = myContext.Books.Include(nameof(Book.authors))
       .Select(b => new { 
          b.Name, 
          b.Content, 
          b.authors })
       .ToList()
       .Select(b => new {
          b.Name,
          b.Content,
          AuthorNames = string.Join(", ", b.authors.Select(a => a.Name))
       });
