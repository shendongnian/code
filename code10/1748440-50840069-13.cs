    int maxPossibleTextBoxCount = 3;
    int selectedTextBoxCount = ContentPlaceHolder1.Controls.OfType<TextBox>().Count();
    int emptyTextBoxCount = maxPossibleTextBoxCount - selectedTextBoxCount;
    using (var command = new SqlCommand("PP_CreateIDNumber", connection)) {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@userNum", lblUser.Text);
        int counter = 1;
        // Here we add the parameters for the selected textboxes.
        foreach(TextBox textBox in ContentPlaceHolder1.Controls.OfType<TextBox>()) {
            command.Parameters.AddWithValue($"@ID{counter++}", textBox.Text);
        }
        // Here we add the parameters for the non-selected textboxes.
        if(emptyTextBoxCount > 0) {
            for(int i = 0; i < emptyTextBoxCount - 1; i++) {
                command.Parameters.AddWithValue($"@ID{counter++}", System.DBNull.Value);
            }
        }
        command.ExecuteNonQuery();
    }
