    SqlTransaction tx = connection.BeginTransaction();
    SqlCommand comm1 = new SqlCommand("UPDATE count set ETR=@ETR WHERE Id=@ID", connection);
    comm1.Connection = connection;
    comm1.Transaction = transaction;
    comm1.Parameters.Add("@ID", System.Data.SqlDbType.Int);
    comm1.Parameters.Add("@ETR", System.Data.SqlDbType.VarChar, 50);
    for(int i = 0; i < itemIDs.Count; i++) {
      
      
      
        comm1.Parameters["@ETR"].Value = itemIDs[i];
      
        comm1.Parameters["@ETR"].Value = delivery[i];
        comm1.ExecuteNonQuery();
     }
     tx.Commit();
