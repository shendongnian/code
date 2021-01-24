    public static DialogResult ShowDialog()
    {
    	var inputBox = new Form { ClientSize = new Size(520, 225), FormBorderStyle = FormBorderStyle.FixedDialog };
    	var label = new Label { Text = "Text", Location = new Point(25, 90), Visible = true };
      
    	inputBox.Controls.Add(CreateTextBox(25, 25,label));
    	inputBox.Controls.Add(CreateTextBox(25, 60,label));
    	inputBox.Controls.Add(label);
    
    	return inputBox.ShowDialog();
    }
