            SqlConnection myConnection =
                new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=TESTdatabase;Integrated Security=True");
            SqlCommand myCommand = new SqlCommand(
                "INSERT into tblGenerator (GeneratorName, GeneratorAddress, GeneratorCity, GeneratorState, GeneratorZip, GeneratorPhone, GeneratorContact, GeneratorEPAID)" +
                "VALUES (@GenName, @GenAdd, @GenCity, @GenState, @GenZip, @GenPhone, @GenContact, @GenEPAID)");
            myCommand.Parameters.AddWithValue("@GenName", GenName.Text);
            myCommand.Parameters.AddWithValue("@GenAdd", GenAdd.Text);
            myCommand.Parameters.AddWithValue("@GenCity", GenCity.Text);
            myCommand.Parameters.AddWithValue("@GenState", GenState.Text);
            myCommand.Parameters.AddWithValue("@GenZip", GenZip.Text);
            myCommand.Parameters.AddWithValue("@GenPhone", GenPhone.Text);
            myCommand.Parameters.AddWithValue("@GenContact", GenContact.Text);
            myCommand.Parameters.AddWithValue("@GenEPAID", GenEPAID.Text);
            myConnection.Open();
            myCommand.Connection = myConnection;
            MessageBox.Show("You Have Successfully Added a New Generator To SQL");
            myCommand.ExecuteNonQuery();
            myConnection.Close();
