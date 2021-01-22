    DataContext ctxA = new DataContext();
    DataContext ctxB = new DataContext();
    
    Author orwell = new Author {Name = "George Orwell" };
    ctxA.Add(orwell);
    ctxB.Add(new Book {Name = "1984", Author = orwell});
    
    ctxA.SaveChanges();
    ctxB.SaveChanges();
