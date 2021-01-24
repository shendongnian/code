        String name = "test0";
            SqlCommand cmd = new SqlCommand();
            SqlParameter t = new SqlParameter("@param2", System.Data.SqlDbType.VarChar, 50);
            t.Value = name;
            cmd.Parameters.Add(new SqlParameter("@param2", System.Data.SqlDbType.VarChar, 50).Value = name);
            cmd.Parameters.Add(t);
