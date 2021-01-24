        using (var command = new SqlCommand("PP_CreateIDNumber", connection)) {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userNum", lblUser.Text);
            int counter = 1;
            foreach(TextBox textBox in ContentPlaceHolder1.Controls.OfType<TextBox>()) {
                command.Parameters.AddWithValue($"@ID{counter++}", textBox.Text);
            }
            command.ExecuteNonQuery();
        }
