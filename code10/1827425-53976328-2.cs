    Models model = new Models();
    var actor = new Actor
    {
        Date_Of_Birth = DateTime.Now,
        First_Name = "first name",
        Last_Name = "last name"
    }; 
    var movie = new Movie
    {
        publishDate = DateTime.Now,
        Name = "movieN"
    };
    model.Movies.Add(movie);
    model.SaveChanges();
    
    //adding new relation 
    var foundAct = model.Actors.SingleOrDefault(x => x.ActorId == 1);
    foundAct.Plays.Add(new Play
    {
        ActorID = foundAct.ActorId,
        MovieID = 2// MovieId from Db
    }); 
    model.SaveChanges(); 
