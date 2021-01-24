    try{
        foreach (var item in overrides)
        {
            using (SqlCommand cmd = new SqlCommand("up_UpdateOverrideTable", conn, tran))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                    // add parameters here 
                var response = cmd.ExecuteNonQuery();
                completedInserts.Add(new OverrideItem(item.Id, Convert.ToBoolean(response)));
            }
        }
    }
    catch (Exception ex)
    {
        tran.Rollback();
        throw;
    }
    tran.Commit();
    conn.Close();
