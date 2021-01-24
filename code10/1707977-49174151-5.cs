    Database.SetInitializer<MuseumContext>(new DropCreateDatabaseIfModelChanges<MuseumContext>());
    using (var dbContext = new MuseumContext())
    {
        Genre goldenAge = dbContext.Genres.Add(new Genre() { Name = "Dutch Golden Age Painting" });
        Genre renaissance = dbContext.Genres.Add(new Genre() { Name = "Early Renaissance" });
        Genre portrets = dbContext.Genres.Add(new Genre() { Name = "Portrets" });
        Genre popArt = dbContext.Genres.Add(new Genre() { Name = "Pop Art" });
        // The RijksMuseum Amsterdam has a Collection of several genres,
        Museum rijksMuseum = dbContext.Museums.Add(new Museum()
        {
            Name = "RijksMuseum Amsterdam",
            Genres = new List<Genre>()
            {
                goldenAge,
                renaissance,
                portrets,
            },
        });
        // Rembrandt van Rijn can be seen in the Rijksmuseum:
        Artist artist = dbContext.Artists.Add(new Artist()
        {
            Name = "Rembrandt van Rijn",
            Museum = rijksMuseum,
            // he painted in several Genres
            Genres = new List() {goldenAge, portrets},
        });
        dbContext.SaveChanges();
    }
