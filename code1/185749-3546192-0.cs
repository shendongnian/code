    SqlConnection cn = null;
    try
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString());
        cn.Open();
        // Set all previous settings to inactive
        using (SqlCommand cmd = new SqlCommand("UPDATE tblSiteSettings SET isActive = 0", cn))
        {
            cmd.ExecuteNonQuery();
        }
        cn.Close();
    }
    finally
    {
        if ( cn != null )
            cn.Dispose();
    }
