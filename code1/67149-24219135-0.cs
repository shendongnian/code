            if (sender is TextBox)
            {
                TextBox textbox = sender as TextBox;
                if (string.IsNullOrEmpty(textbox.Text))
                {
                    MessageBox.Show("Please enter correct value value..");
                    textbox.Focus();
                }
            }
        }
