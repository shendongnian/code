    var playersWitGames = dbContext.Players
       .Where(player => ...)
       .Select(player => new
       {   // select only the properties you plan to use
           Id = player.Id,
           Name = player.Name,
           // not needed for this query: Birthday, emergency telephone number,
           // bank account, marital status
           Games = player.PlayedGames
               .Where(game => ...) // if you don't need all games
               .Select(game => new
               {
                    // not sure if needed: game.Id
                    // certainly not needed: game.PlayerId
                    Date = game.Date,
                    Score = game.Score,
                    ...
                })
                .ToList(),
       });
