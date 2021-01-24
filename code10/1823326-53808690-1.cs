    var conString = "Data Source=DESKTOP-86TC1QA\\MSSSQLSERVER17;Initial Catalog=AttendanceApp;Integrated Security=True";
    
    using (var connection = new SqlConnection(connectionString)) {
        connection.Open();
        using (var command = new SqlCommand("SELECT * FROM Location_Table WHERE Location 
        = @location", connection)) {
            command.Parameters.Add(new SqlParameter("location", Int32.Parse(location_comboBox.SelectedValue.ToString());
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var Miles = (string)dr["Miles"].ToString();
                mileage_textbox.Text = Miles;
            }
        }
    }
