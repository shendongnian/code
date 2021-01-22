    // Create a sequence. 
    Item[] items = new Item[] 
    { new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"}, 
      new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
      new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
      new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};
    
    // Query for items with price greater than 9.99.
    var query = from i in items
                 where i.Price > 9.99
                 orderby i.Price
                 select i;
    
    // Load the query results into new DataTable.
    DataTable table = query.CopyToDataTable();
