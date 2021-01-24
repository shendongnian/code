	protected void Button_Save_Click(object sender, EventArgs e)
	{
		string connectionStr = ConfigurationManager.ConnectionStrings["ORAProjectConnectionString"].ConnectionString;
		// the query string should be **ONLY** the stored procedure name - nothing else!
		string query = "dbo.sp_UpdateProj";
		// you should put **both** SqlConnection and SqlCommand in "using" blocks
		using (SqlConnection con = new SqlConnection(connectionStr))
		using (SqlCommand cmd = new SqlCommand(query, con))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			// fill the parameters - avoiding "AddWithValue"
			cmd.Parameters.Add("@ORAID", SqlDbType.Int).Value = Convert.ToInt32(TextBox_ORAID.Text);
			cmd.Parameters.Add("@FullTitle", SqlDbType.NVarChar, 250).Value = TextBox_FullTitle.Text;
			con.Open();
			// you need to **EXECUTE** the command !
			cmd.ExecuteNonQuery();
			con.Close();
		}
	}
