    internal static bool SupressConnectionDispose { get; set; }
    public void Dispose()
    {
       if (Connection.State == ConnectionState.Open)
       {
           Connection.ChangeDatabase(
               DatabaseInfo.GetDatabaseName(OriginalDatabase));
       }
       if (Connection != null 
           && --ConnectionReferences <= 0 
           && !SuppressConnectionDispose)
       {
           if (Connection.State == ConnectionState.Open)
               Connection.Close();
           Connection.Dispose();
       }
    }
