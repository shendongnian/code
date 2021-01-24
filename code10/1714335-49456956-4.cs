	static void Main(string[] args)
	{
		//var supports almost all types of data, which simplifies the object declaration process
		var CRInput = new Input();
		Console.WriteLine(CRInput.EvalInput(Console.ReadLine()));
	}
	//Class names must start with capitals
	private class Input
	{
		public string InputString { get; set; }
		public string EvalInput(string input)
		{
			//Initialize result with the value -> ""
			string result = string.Empty;
			//The switch structure simplifies and shortens the repetitive use of else if
			switch (input)
			{
				//if
				case "1":
				   result = "1"; 
				   break;
				//else if
				case "2": 
				   result = "2"; 
				   break;
				//else if
				case "3": 
				   result = "3"; 
				   break;
				//else
				default: 
				   result = "NOTHING";
				   break;
			}
			return result;
		}
	}
