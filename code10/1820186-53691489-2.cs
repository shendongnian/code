    private void button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(textBox1.Text.Trim())) ExecuteCommands(textBox1.Text.Trim().ToLower());
    }
    
    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if(e.KeyCode==Keys.Enter && !string.IsNullOrEmpty(textBox1.Text.Trim()))
        {
            ExecuteCommands(textBox1.Text.Trim().ToLower());
        }
    }
    
    private void ExecuteCommands(string command)
    {
        switch(command)
        {
            case "start()":
                // yout code
                break;
             case "stop()":
                // your code
                break;
             default:
                MessageBox.Show("Can't recognize command");
                break;
        }
    }
