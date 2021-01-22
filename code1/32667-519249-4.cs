    public void AppendTextBox(string value)
    {
    	if (InvokeRequired)
    	{
    		this.Invoke(new Action<string>(AppendTextBox), new object[] {value});
    		return;
    	}
    	ActiveForm.Text += value;
    }
