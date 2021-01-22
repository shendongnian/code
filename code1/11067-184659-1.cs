    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (SqlTransaction transaction = conn.BeginTransaction())
        {
            using (SqlCommand updateCommand = new SqlCommand(update, conn, transaction))
            {
                string uid = Session["uid"].ToString();
                updateCommand.Parameters.AddWithValue("@ID", uid);
                updateCommand.Parameters.AddWithValue("@qnum", i);
                updateCommand.Parameters.Add("@answer", System.Data.SqlDbType.VarChar);
                for (int i = tempStart; i <= tempEnd; i++)
                {
                    updateCommand.Parameters["@answer"] = Request.Form[i.ToString()];
                    updateCommand.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        } // Transaction will be disposed and rolled back here if an exception is thrown
    }
