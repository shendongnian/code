    public static DataTable getAllModifiedChargesToday(int practiceID)
    {
        DataTable dt = new DataTable();
    
        try
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnString"].ToString()))
            {
                conn.Open();
    
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ch_getAllModifiedChargesToday";
                    cmd.Parameters.AddWithValue("@practiceID", practiceID);
    
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    
        return dt;
    }
