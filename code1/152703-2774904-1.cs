    void myButton_Click(object sender, EventArgs e) {
        try {
            myInputTextBox.Enabled = false;
            myButton.Enabled = false;
    
            var input = ParseInput(myTextBox.Text);
    
            var output = ExecuteMethodWithInput(input);
    
            myOutputTextBox.Text = FormatOutput(output);
    
        } finally {
            myTextBox.Enabled = true;
            myButton.Enabled = true;
        }
    }
