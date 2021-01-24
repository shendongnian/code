            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "insert into NewName  values('" + first_Name.Text + "','" + last_Name.Text + "','" + user.Text + "','" + email.Text + "','" + password.Text + "','" + contact.Text + "')";
         
            command = new SqlCommand(sql, con);
            adapter.InsertCommand = new SqlCommand(sql, con);
            // this line here is showing the error
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            con.Close();
