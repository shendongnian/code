    var table1 = new[] { // 
        new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes" , Label = "duplicate"},
        new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez", Label = "original"}
    };
    var table2 = new[] {
        new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes" , Label = "duplicate"},
        new Movie{Id = 1, Price = 13.40, Genre = "Foo", Director = "BAR", Label = "original"}
    };
    // ReOrdering and From List<T> To DataTable
    DataTable dataTable1 = new DataTable();
    using (var reader =
            ObjectReader.Create(        // 1, 2, 3, 4,5
                table1.Select(x => new { x.Id, x.Price, x.Genre, x.Director, x.Label })
            )
        )
    {
        dataTable1.Load(reader);
    }
    DataTable dataTable2 = new DataTable();
    using (var reader =
            ObjectReader.Create(        // 2,3,1,4,5
                table2.Select(x => new { x.Price, x.Genre, x.Id, x.Director, x.Label })
            )
        )
    {
        dataTable2.Load(reader);
    }
