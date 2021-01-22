    public class GameCatalog : IGameCatalog
    {
      Uri theServiceRoot;
      GamesEntities theEntities;
      const int MAX_RESULTS = 50;
    
      public GameCatalog() : this(new Uri("/Games.svc", UriKind.Relative))
      {
      }
    
      public GameCatalog(Uri serviceRoot)
      {
        theServiceRoot = serviceRoot;
      }
    
      public event EventHandler<GameLoadingEventArgs> GameLoadingComplete;
      public event EventHandler<GameCatalogErrorEventArgs> GameLoadingError;
      public event EventHandler GameSavingComplete;
      public event EventHandler<GameCatalogErrorEventArgs> GameSavingError;
    
      public void GetGames()
      {
        // Get all the games ordered by release date
        var qry = (from g in Entities.Games
                   orderby g.ReleaseDate descending
                   select g).Take(MAX_RESULTS) as DataServiceQuery<Game>;
    
        ExecuteGameQuery(qry);
      }
    
      public void GetGamesByGenre(string genre)
      {
        // Get all the games ordered by release date
        var qry = (from g in Entities.Games
                   where g.Genre.ToLower() == genre.ToLower()
                   orderby g.ReleaseDate
                   select g).Take(MAX_RESULTS) as DataServiceQuery<Game>;
    
        ExecuteGameQuery(qry);
      }
    
      public void SaveChanges()
      {
        // Save Not Yet Implemented
        throw new NotImplementedException();
      }
    
      // Call the query asynchronously and add the results to the collection
      void ExecuteGameQuery(DataServiceQuery<Game> qry)
      {
        // Execute the query
        qry.BeginExecute(new AsyncCallback(a =>
        {
          try
          {
            IEnumerable<Game> results = qry.EndExecute(a);
    
            if (GameLoadingComplete != null)
            {
              GameLoadingComplete(this, new GameLoadingEventArgs(results));
            }
          }
          catch (Exception ex)
          {
            if (GameLoadingError != null)
            {
              GameLoadingError(this, new GameCatalogErrorEventArgs(ex));
            }
          }
    
        }), null);
      }
    
      GamesEntities Entities
      {
        get
        {
          if (theEntities == null)
          {
            theEntities = new GamesEntities(theServiceRoot);
          }
          return theEntities;
        }
      }
    }
