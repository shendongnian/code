    using (SqlConnection conn = new SqlConnection(conString))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = 
            "INSERT INTO Persons (PersonID,LastName,FirstName,Age,City) VALUES (@PersonID,@LastName,@FirstName,@Age,@City)";
        cmd.Parameters.AddWithValue("@PersonID", int.Parse(txtPersonID.Text));
        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
        cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
        cmd.Parameters.AddWithValue("@City", txtCity.Text);
        cmd.Connection = connection;
        conn.Open();
        int rowsAffected = cmd.ExecuteNonQuery();
        if(rowsAffected > 0)
        {
            MessageBox.Show("Data inserted");
        }
        else
        {
           MessageBox.Show("Failed");
        }
        conn.Close();
    }
