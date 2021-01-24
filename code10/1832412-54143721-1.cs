    T RunQuery(YourDB db, string qry)
    {
       lock (l)
       {
           try
           {
               T data = db.Query<T>(qry);
               return data;
           }
           catch (Exception ex)
           {
              db.Rollback();
              Debug.WriteLine(ex);
              Console.WriteLine(qry);
              throw;
           }
        }
     }
