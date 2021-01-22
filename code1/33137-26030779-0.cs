    private void OnMyTextBoxTyping(object sender, EventArgs e)
    {
    	if (!System.Text.RegularExpressions.Regex.IsMatch(myTextBox.Text, @"^[0-9]+$"))
    	{
    		var currentPosition = myTextBox.SelectionStart;
    		myTextBox.Text = new string(myTextBox.Text.Where(c => (char.IsDigit(c))).ToArray());
    		myTextBox.SelectionStart = currentPosition > 0 ? currentPosition - 1 : currentPosition;
    	}
    }
