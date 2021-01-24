    protected void Button_Save_Click(object sender, EventArgs e)
    {
     string connectionStr = ConfigurationManager.ConnectionStrings["ORAProjectConnectionString"].ConnectionString;
     string procedureName = "dbo.UpdateProj";
    
     using (SqlConnection con = new SqlConnection(connectionStr))
     using(SqlCommand cmd = new SqlCommand(procedureName , con))
     {
   
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ORAID", Convert.ToInt32(TextBox_ORAID.Text));
        cmd.Parameters.AddWithValue("@FullTitle", TextBox_FullTitle.Text);
        con.Open();
        cmd.ExecuteNonQuery()
        con.Close();
     }
    }
