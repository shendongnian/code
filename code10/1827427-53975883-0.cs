    private void AddPhBttn_Click(object sender, RoutedEventArgs e)
    {
        // Necessary input validation to collect and data from input fields. Good practice to avoid SQL injection.
        AddFurniture(nameTxtBox.Text, phoneTxtbox.Text, dateTxtBox.Text, puDateTxtBox.Text);
    }
    
    private void AddFurniture(string name, string phoneNumber, string createdDate, string pickupDate)
    {
        string connectionString = "Data Source=LAPTOP-F4QFMPFD\\MSSQLSERVER1;Initial Catalog=Furniture;Integrated Security=True"; // This should ideally come from some configuration.
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction = connection.BeginTransaction("Add Furniture");
            command.Connection = connection;
            command.Transaction = transaction;
        
            try
            {
                 connection.Open();
                command.CommandText = $"insert into Customers (Name, Phone) values ({name}, {phoneNumber});";
                command.ExecuteNonQuery();
                command.CommandText = $"insert into PriceHold (DateCreated, PickUpDate) values ({createdDate}, {pickupDate});";
                command.ExecuteNonQuery();
            
                // Try to commit to database.
                // Both the above queries are executed at this point. If any one of them fails, 'transaction' will throw an exception.
                transaction.Commit();
            }
            catch (Exception ex1)
            {
                // Considering the statements executed using the 'transaction' for this 'connection',
                // one of the insert operations have clearly failed.
                // Attempt to roll back the change which was applied.
                MessageBox.Show($"Insert failed. Trying to roll back {ex1.Message}");
                try
                {
                    transaction.RollBack();
                }
                catch (Exception ex2)
                {
                    // Rollback also failed. Possible data integrity issue. Handle it in your application.
                    MessageBox.Show($"Roll back failed. {ex2.Message}");
                }
             }
         }
    }
