    protected void Button_Save_Click(object sender, EventArgs e)
    {
    string connectionStr = ConfigurationManager.ConnectionStrings["ORAProjectConnectionString"].ConnectionString;
     using (SqlConnection con = new SqlConnection(connectionStr))
     {
        con.Open();
        string procedureName = "UpdateProj";
        SqlCommand cmd = new SqlCommand(procedureName , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@ORAID", Convert.ToInt32(TextBox_ORAID.Text));
        cmd.Parameters.AddWithValue("@FullTitle", TextBox_FullTitle.Text);
        cmd.ExecuteNonQuery()
        con.Close();
     }
    }
