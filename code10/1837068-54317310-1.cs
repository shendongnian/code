    database.GetCollection<Movie>("Movies")
        .Aggregate()
        .Unwind<Movie, Movie>(x => x.Genres)
        .Group(x=>x.Genres, g => new
        {
            Count = g.Count()
        }).As<GenreStats>().ToList();
