    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
        if (rdr.HasRows)
        {
            Response.Write("double booking");
        }
        else
        {
            string insertQuery = "INSERT INTO Ticket (BusNo, Date, Time,Bickup,DropOff,Fare) VALUES (@busno ,@date , @time , @bickup , @dropoff ,@fare )";
            SqlCommand cmd2 = new SqlCommand(insertQuery, con);
            cmd2.Parameters.AddWithValue("@busno", tbBusno.Text);
            cmd2.Parameters.AddWithValue("@date", DateTime.Parse(tbDate.Text));
            cmd2.Parameters.AddWithValue("@time", tbTime.Text);
            cmd2.Parameters.AddWithValue("@dropoff", tbDrop.Text);
            cmd2.Parameters.AddWithValue("@bickup", tbBickup.Text);
            cmd2.Parameters.AddWithValue("@fare", int.Parse(tbfare.Text));
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
    }
