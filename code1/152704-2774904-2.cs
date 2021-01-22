    void myButton_Click(object sender, EventArgs e) {
        try {
            myInputTextBox.Enabled = false;
            myButton.Enabled = false;
    
            var input = ParseInput(myInputTextBox.Text);
    
            var output = ExecuteMethodWithInput(input);
    
            myOutputTextBox.Text = FormatOutput(output);
    
        } finally {
            myInputTextBox.Enabled = true;
            myButton.Enabled = true;
        }
    }
