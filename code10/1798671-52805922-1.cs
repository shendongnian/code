    specificBookForAuthor = _context.Books.Where(c => 
        (c.Author.Name.Contains(First) || c.Author.Surname.Contains(Last)));
    
    if(!string.IsNullOrEmpty(book))
        specificBookForAuthor = specificBookForAuthor.Where(c => c.Name.Contains(book));
  
    if(!string.IsNullOrEmpty(country))
        specificBookForAuthor = specificBookForAuthor.Where(c => c.Author.Country.Name.Contains(country));
    
    //....and so on with your other conditions;
    //....finally:
    
    specificBookForAuthor = specificBookForAuthor.ToList(); 
  
