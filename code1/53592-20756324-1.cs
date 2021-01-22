        private void txtData1_GetFocus(object sender, RoutedEventArgs e)
        {
            if (txtData1.Text == "TextBox1abc")
            {
                txtData1.Text = string.Empty;
            }
        }
        private void txtData1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtData1.Text == string.Empty)
            {
                txtData1.Text = "TextBox1abc";
            }
        }
