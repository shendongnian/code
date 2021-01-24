	protected void BtnLogin_Click(object sender, EventArgs e)
	{
		cmd.CommandText = cmd.CommandText = "SELECT * FROM Person where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'";
		cmd.Connection = con;
		sda.SelectCommand = cmd;
		sda.Fill(ds, "Person");
		if (ds.Tables[0].Rows.Count > 0)
		{
			if(ds.Tables[0].Rows[0]["PersonType"] == DropDownList3.SelectedValue)
			{
				Response.Redirect(url: "http://localhost:56061/");
			}
			else
			{
				Label1.Text = "Invalid User Type. Please Try Again!";
			}
		}
		else
		{
			Label1.Text = "Invalid User Type, Username or Password. Please Try Again!";
		}
	}
