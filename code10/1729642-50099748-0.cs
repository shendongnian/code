    StringBuilder text = new StringBuilder();
    if (textbox1.Text == "" && textbox2.Text == "" && textbox3.Text == "")
    {
    	text.Append("boxes empty");
    }
    else
    {
    	int count = 0;
    	text.Append(CheckTextBox(textbox1, ref count, 1));
    	text.Append(CheckTextBox(textbox2, ref count, 2));
    	text.Append(CheckTextBox(textbox3, ref count, 3));
    
    	text.Append("are not empty");
    }
    public string CheckTextBox(TextBox textbox, ref int count, int boxNumber)
	{
		string text = "";
		if (!string.IsNullOrEmpty(textbox.Text))
		{
			if (count > 0)
		    {
		        text += "& ";
		    }
			text+=$"{boxNumber} ";
		}
		return text;
	}
