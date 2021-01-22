        private void txtContents2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.Parse(txtContents2.Text) > int.Parse(mainBlock.txtContents))
            {
                mainBlock.txtContents2 = "000";
                txtContents2.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            }
            else
            {
                mainBlock.txtContents2 = txtContents2.Text;
                txtContents2.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }
