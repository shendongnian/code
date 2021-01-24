    switch(selectedUser)
    {
        case "Guest": return ShowForm(new Form3());
        case "Admin":
            if(textBox1.Text == "password")
            {
                return ShowForm(new Form1());
            }
            else
            {
                MessageBox.Show("Password is incorrect!", "ERROR!");
            }
        case "Limited":
            if(textBox1.Text == "limited")
            {
                return ShowForm(new Form2());      
            }
            else
            {
                MessageBox.Show("Password is incorrect!", "ERROR!");
            }
        default: break;
    }
