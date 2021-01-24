    Dictionary<string, string> users = Enumerable.Range(0, credentials.GetLength(0)).ToDictionary(i => credentials[i, 0], i => credentials[i, 1]);
    
    if(users[textBox1.Text] != null && users[textBox1.Text] == textBox2.Text){
        MessageBox.Show("Success");
    }
