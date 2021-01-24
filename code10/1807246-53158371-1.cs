    using (SqlCommand cmd2 = new SqlCommand(timestamp, con))
    {
        cmd2.Parameters.Add("@User_ID", SqlDbType.Int).Value = Session["UserID"];
        if ((int)cmd2.ExecuteScalar() == 1)
        {
            lblMessage.Text = "The account's status is suspended.";
            lblMessage.Visible = true;
        }
    }
