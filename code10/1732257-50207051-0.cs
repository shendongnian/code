              using (MySqlTransaction trans = conn.BeginTransaction())
              {
                  foreach (var item in tag.RelativeList)
                  {
            using (MySqlCommand cmd = new MySqlCommand("sp_insert_relative",conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            })
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
        
                cmd.Parameters.AddWithValue("_ancestor_id", id);
                cmd.Parameters.AddWithValue("_rgn", item.RGN);
                cmd.Parameters.AddWithValue("_rsn", item.RSN);
                cmd.Parameters.AddWithValue("_sgn", item.SGN);
                cmd.Parameters.AddWithValue("_ssn", item.SN);
                cmd.Parameters.AddWithValue("_username", tag.Username);
                cmd.Parameters.AddWithValue("_fname", System.IO.Path.GetFileName(tag.FileName));
                cmd.ExecuteNonQuery();
            }
    trans.commit
        }
    }
