    private void deleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            int index = dataGridViewClients.CurrentRow.Index;
            if(!CheckBox1.Checked ||
               MessageBox.Show("Do you want to delete record?", "Message", 
               MessageBoxButtons.YesNo)==DialogResult.Yes){
                 ClientValidation.DeleteClient(clientVM.Clients[index]);
            }
        }
    }
