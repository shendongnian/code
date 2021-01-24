    private void button1_Click(object sender, EventArgs e)
    {
        string selectedUser = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        string selectedPassword = this.textbox1.Text;
        if (!IsPasswordCorrect(selectedUser, selectedPassword))
        {
            MessageBox.Show("Password is incorrect!", "ERROR!");
        }
        else
        {
            var form = CreateFormForUser(selectedUser);
            form.Show();
            form.Activate();
            this.Hide();
        }
    }
