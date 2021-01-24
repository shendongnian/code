    string timestamp = @"SELECT 1 FROM SuspensionRecord sr WHERE sr.User_ID = @User_ID AND supensiondate > @now";
	using (SqlCommand cmd2 = new SqlCommand(timestamp, con))
	{
		cmd2.Parameters.Add("@User_ID", SqlDbType.Int).Value = Session["UserID"]; // do not convert to string
		cmd2.Parameters.Add("@now", SqlDbType.DateTime).Value = DateTime.Now.Date;
		var result = cmd2.ExecuteScalar();
		if(result != null) // if null then there were no records so account is not suspended
		{
			lblMessage.Text = "The account's status is suspended.";
			lblMessage.Visible = true;
		}
    }
