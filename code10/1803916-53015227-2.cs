    using (SqlCommand cmd = new SqlCommand("Select * from Products where ID=" + PID, con))
    {
        cmd.CommandType = CommandType.Text;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            sda.Fill(dt);
        }
    }
