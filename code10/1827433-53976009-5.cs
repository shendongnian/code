    private void AddPhBttn_Click(object sender, RoutedEventArgs e)
    {
         var furniture = new SqlConnection("Data Source=LAPTOP-F4QFMPFD\\MSSQLSERVER1;Initial Catalog=Furniture;Integrated Security=True");
    
         SqlCommand add = new SqlCommand("usp_InsertData", furniture);
         add.CommandType = System.Data.CommandType.StoredProcedure;
    
         add.Parameters.AddWithValue("@Name", nameTxtBox.Text);
         add.Parameters.AddWithValue("@Phone", phoneTxtbox.Text);
         add.Parameters.AddWithValue("@DateCreated", dateTxtBox.Text);
         add.Parameters.AddWithValue("@PickUpDate", puDateTxtBox.Text);
         furniture.Open();
    
         int i = add.ExecuteNonQuery();
    
         if (i != 0)
         {
              MessageBox.Show("saved");
         }
         else
         {
             MessageBox.Show("error");
         }
         furniture.Dispose();
    
    }
