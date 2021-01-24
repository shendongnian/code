      protected void Button_srch_invest1_Click(object sender, EventArgs e)
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["ORAProjectConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionStr))
        {
            
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_SrcProtocols";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = TextBox_Srch.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
          
          
            con.Close();
           
        }
    }
