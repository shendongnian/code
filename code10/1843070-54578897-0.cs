    using (var context = new MovieContext())
    {
        List<Movie> movieList = context.Movies
                                       .Include(m => m.Revenue)   // ADD THIS INCLUDE
                                       .ToList();
        Console.WriteLine("Movie Name: " + movieList[0].Name);
    
        if (movieList[0].Revenue == null)
        {
            Console.WriteLine("Revenue is null!");
        }
        else
        {
            Console.WriteLine(movieList[0].Revenue.GrossIncome);
        }
    
        Console.ReadLine();
    }
