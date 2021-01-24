    private void LookUpBtn_Click(object sender, RoutedEventArgs e)
    {
        SqlDataReader reader = ConnectionClass.Query("SELECT * WHERE customer_id = '" + customerIdTextbox.Text + "';")
        if (reader.Read())
        {
            //reader[0] probably is CustomerId
            NameTextbox.Text = reader[1].ToString();
            LastNameTextbox.Text = reader[2].ToString();
            PhoneNumberTextbox.Text = reader[3].ToString();
            CellphoneNumberTextbox.Text = reader[4].ToString();
            AddressTextbox.Text = reader[5].ToString();
        }
    }
