    Game game = db.Games.Find(id);
    if (game != null)
    {
        game.Reviews = db.Reviews.Where(r => r.GameId == game.Id).ToList();
    }
         
