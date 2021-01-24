    protected void Button_Save_Click(object sender, EventArgs e)
    {
     string connectionStr = ConfigurationManager.ConnectionStrings["ORAProjectConnectionString"].ConnectionString;
     string procedureName = "UpdateProj";
     using(SqlCommand cmd = new SqlCommand(procedureName , con))
     using (SqlConnection con = new SqlConnection(connectionStr))
     {
   
        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@ORAID", Convert.ToInt32(TextBox_ORAID.Text));
        cmd.Parameters.AddWithValue("@FullTitle", TextBox_FullTitle.Text);
        con.Open();
        cmd.ExecuteNonQuery()
        con.Close();
     }
    }
