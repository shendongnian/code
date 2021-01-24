    using (SqlConnection connection = new SqlConnection(connectionstr))
        {
            connection.Open();
            // Delete old entries
            SqlTransaction trans = connection.BeginTransaction();
            string sql = "Delete  from PhilaMethod ";
            SqlCommand cmd = new SqlCommand(sql, connection, trans);
            cmd.ExecuteNonQuery(); // <--- added this
            trans.Commit();
            connection.Close();
        }
