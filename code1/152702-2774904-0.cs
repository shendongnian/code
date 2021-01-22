    void myButton_Click(object sender, EventArgs e) {
        try {
            myTextBox.Enabled = false;
            myButton.Enabled = false;
    
            var input = ParseInput(myTextBox.Text);
    
            var output = ExecuteMethodWithInput(input);
    
            DisplayOutput(output);
    
        } finally {
            myTextBox.Enabled = true;
            myButton.Enabled = true;
        }
    }
