      public IEnumerable<IDataReader> getIDataReader(string sql)
    {
        using (SqlConnection conn = new SqlConnection("cadena de conexion"))
        {
            using (SqlCommand da = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader dr = da.ExecuteReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read)
                        {
                            yield return dr;
                        }
                    }
                }
                conn.Close();
            }
        }
    }
