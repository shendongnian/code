    // Create a DateTime object from your controls, instead of a string representation.
    var year = int.Parse(txtYear.Text);
    var month = int.Parse(comboMM.SelectedValue);
    var day = int.Parse(ComboDD.SelectedValue);
    var dateOfBirth = new DateTime(year, month, day);
            
    // Use parameters in your query instead of appending the string values
    var query = "Insert into dbo.membertable(Given_Names, Last_Name, DOb, OtherFields) Values(@GivenNames, @LastName, @DOB, @OtherParameters);";
            
    // Wrap your SqlConnection and SqlCommand in using blocks to ensure they are disposed correctly.
    var connString = ConfigurationManager.ConnectionStrings["PottersDB"].ConnectionString;
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (var cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@GivenNames", txtnames.Text);
            cmd.Parameters.AddWithValue("@LastName", txtFamilyname.Text);
            cmd.Parameters.AddWithValue("@DOB", dateOfBirth);
            // As the query is just inserting, there's no need to create a data reader.
            cmd.ExecuteNonQuery();
        }
    }
