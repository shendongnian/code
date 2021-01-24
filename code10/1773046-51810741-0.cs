     con.Open();
    
     bool readerHasRows = false;
     string brid = txtBr_id.Text;
     String syntax = "SELECT book1, book2 FROM Borrowes WHERE brId = @brid AND (book1 IS NOT NULL OR book2 IS NOT NULL)";
    
     using (SqlCommand cmd = new SqlCommand(syntax, con))
     {
         cmd.Parameters.AddWithValue("@brid", txtBr_id.Text);
    
    
         using (SqlDataReader reader = cmd.ExecuteReader())
         {
            readerHasRows = reader.read();
         }
     }
     con.Close();
    
     if (readerHasRows == true)
     {
        MessageBox.Show("This borrower has borrowed the book please collect the book first.");
     }
