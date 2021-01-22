      class SmartDbConnection<T> where T: IDbConnection , new()
      {
        private readonly T Connection;
    
        public SmartDbConnection(string ConnectionString)
        {
          if (ConnectionString.Contains("MultipleActiveResultSets=true"))
          {
            Connection = new T();
            Connection.ConnectionString = ConnectionString;
          }
        }
      }
