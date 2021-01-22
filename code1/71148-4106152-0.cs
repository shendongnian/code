    private void Contact_FormClosing(object sender, FormClosingEventArgs e)
    {
         if (oName!=nameTextBox.Text||oCompany!=companyComboBox.Text)
         {
             DialogResult result = MessageBox.Show("Would you like to save your changes",
                 "Save?",
                 MessageBoxButtons.YesNoCancel,
                 MessageBoxIcon.Stop);
             if (result == DialogResult.Yes)
             {
                 SaveFormValues();
             }
             else if (result == DialogResult.Cancel)
             {
                 // Stop the closing and return to the form
                 e.Cancel = true;
             }
             else
             {
                 this.Close();
             }
         }
    }
     
