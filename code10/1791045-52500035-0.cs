    Dictionary<string, string> users = new Dictionary<string, string>();
    users.Add("name1", "pass");
    users.Add("name2", "pass");
    
    if(users[textBox1.Text] == textBox2.Text){
        MessageBox.Show("Success");
    }
