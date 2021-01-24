    public async task<model> GetMemberList(CancellationToken cancelToken)
    {
       try
       {
           await Task.Run(() =>
           {
               using (var db = _dbFactory.GetConnection())
               {
                  // Code Goes Here....
               }
           }, cancelToken);
       }
       catch
       {
          Throw New Exception(); 
       }
    }
