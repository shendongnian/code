    using (SqlConnection cn = SqlConnectionManager.Instance.GetUserConnection(user)) 
    {
      foreach (Master mRecord in masterList)
      {
      try
      {
        using (SqlTransaction sqlTransaction = cn.BeginTransaction()) 
        {
          using (SqlCommand cm = cn.CreateCommand()) 
          {
            cm.Transaction = sqlTransaction;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "pr_InsertRecords";
            cm.ExecuteNonQuery();
          }
          sqlTransaction.Commit();
          Debug.WriteLine("Auditor.Write: end sql table value param");
        }
      }
      catch (Exception Ex)
      {
        Debug.WriteLine(" Exception message: " + Ex.Message);
      }
    }
