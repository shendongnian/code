    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (SqlCommand updateCommand = new SqlCommand(update, conn))
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
        }
    }
