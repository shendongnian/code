	private void button1_Click(object sender, EventArgs e)
	{
		string automationId = "Form1";
		string newTextBoxValue = "user1";
		var condition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
		var textBox = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, condition);
		ValuePattern vPattern = (ValuePattern)textBox.GetCurrentPattern(ValuePattern.Pattern);
		vPattern.SetValue(newTextBoxValue);
		
        // this is the idea, not tested, adjust it to yourself
		var form2 = new SecondForm();
		form2.YourTextBox.Text = newTextBoxValue;
		form2.Show();
	}
