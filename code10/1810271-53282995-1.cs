		string name = "13Samuel";
		if(name.Length > 2)
		{
			int number;
			if(Int32.TryParse(name.Substring(0,2), out number)){
				Console.WriteLine(number > 0 && number < 99 & Char.IsLetter(name[2]) ? "Success" : "Failed");
			}
				
		}
