    private void button1_Click(object sender, EventArgs e)
    {
        var nextForm = new Form1();
        nextForm.Text1 = comboBox2.Text;
        nextForm.Text2 = comboBox1.Text;
        nextForm.Text3 = textBox1.Text;
        string selectedUser = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        if ((selectedUser == "admin") && (textBox1.Text == "password"))
        {
            nextForm.Show();
            nextForm.Activate();
            this.Hide();
        }
    }
    
