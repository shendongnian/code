    public IEnumerable<object> GetAllGames()
    {
       var games = db.Games.Include(d => d.DailyDatas)
                    .GroupBy(d => new { d.name, d.year })
                    .OrderBy(d => d.Key.name)
                    .Select(d => new
                           {
                            d.Key.year,
                            d.Key.name
                           }
                    );
        return games.ToList();
    }
