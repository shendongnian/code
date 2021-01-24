    var books = myContext.Books
       .Select(b => new { 
          b.Name, 
          b.Content, 
          AuthorNames = b.authors.Select(a => a.Name) 
       })
       .AsEnumerable()
       .Select(b => new {
          b.Name,
          b.Content,
          Authors = string.Join(", ", b.AuthorNames)
       });
