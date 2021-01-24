    private void SubmitBtn_Click(object sender, RoutedEventArgs e)
    {
        if (//!exists)
        {
            CreateNewCustomer();
        }
        else
        {
           ConnectionClass.Query("UPDATE table SET name = '" + NameTextbox.Text + "', lastname = '" + LastNameTextbox.Text + "', phonenumber = '" + PhoneNumberTextbox.Text + "', cellphonenumber = '" + CellphoneNumberTextbox.Text + "', address = '" + AddressTextbox.Text + "' WHERE CustomerID = '" + customerIdTextbox.Text + '";");
        }
    }
