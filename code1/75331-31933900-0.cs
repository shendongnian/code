    private void KeyPressNameSurname(object sender, KeyPressEventArgs e)
     {
         if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsDigit(e.KeyChar) )
         {
            e.Handled = true;
            myTextBox.Text = "Not Valid";
            myTextBox.Visible = true;
         }
         else
         {
            myTextBox.Visible = false;
         }
      }
