    foreach (Control control in Controls)
        if (control is CheckBox)
        {
            SqlConnection cnm = new SqlConnection(connStr);
            cnm.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO services({(control as CheckBox).Tag.ToString()}) VALUES (@a)", cnm);
            cmd.Parameters.AddWithValue("@a", (control as CheckBox).Checked);
            cmd.ExecuteReader();        
    }
