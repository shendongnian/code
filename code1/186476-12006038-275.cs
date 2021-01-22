	void Main()
	{
		string inputValue="John Doe"; 
		inputValue=Interaction.InputBox("Enter user name", "Query", inputValue);
		if (!string.IsNullOrEmpty(inputValue)) // not cancelled and value entered
		{
			inputValue.Dump("You have entered;"); // either display it in results window
			Interaction.MsgBox(inputValue, MsgBoxStyle.OkOnly, "Result"); // or as MsgBox
		}
	}
