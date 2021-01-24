    private void ButtonIssue_Click(object sender, RoutedEventArgs e)
      {
        try
          {
            int book_qty = 0;
            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT BookAvailability  FROM Book_list WHERE BookName = '" + TextBoxBookName + "'";
            cmd2.ExecuteNonQuery();
            var result = cmd2.ExecuteScalar();
            if(result != null && !DBNull.Value.Equals(result)) {
                book_qty = Convert.ToInt32(result);
            }
            if (book_qty > 0)
            // book_qty should be correct now.
