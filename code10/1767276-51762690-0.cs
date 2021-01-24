    protected void Submit_click(object sender, EventArgs e)
    {
        DateTime startdate = Convert.ToDateTime(txtstartdate.Text);
        DateTime enddate = Convert.ToDateTime(txtenddate.Text);
        for (DateTime date = startdate; date <= enddate; date = date.AddDays(1))
        {
            try
            {
                var shtdate = date.ToShortDateString();
                string MyConString = "SERVER=localhost;DATABASE=mydb;UID=myid;PASSWORD=abc123;";
                MySqlConnection connection = new MySqlConnection(MyConString);
                string cmdText = "INSERT INTO approved(agentlogin ,leavetype ,date ,time, reason)VALUES ( @login, @type, @date, 'Full day', @reason)";
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@login", Label1.Text);
                cmd.Parameters.AddWithValue("@type", ddlleavetype.Text);
                cmd.Parameters.AddWithValue("@date", shtdate);
                cmd.Parameters.AddWithValue("@reason", txtreason.Text);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                connection.Close();
                //lblError.Text = "Data Saved";
            }
            catch (Exception)
            {
                Console.Write("not entered");
                //lblError.Text = ex.Message;
            }
        }
    }
