    string[] aNames = new string[10] { "Ronaldo", "Messi", "Aguero", "Dembele", "Reus", "Mbappe", "Sane", "Sterling", "Ibrahimovic", "Alaba" };
		string[] FirstNames = new string[10] {"Cristiano", "Lionel", "Sergio", "Ousmane", "Marco", "Kylian", "Leroy", "Raheem", "Zlatan", "David" };
		Random rd = new Random();
        int randomIndex = rd.Next(0, aNames.Length);
        Console.WriteLine("Enter the First Name of "+aNames[randomIndex]);
		String FirstName = Console.ReadLine();
	    Console.WriteLine("You Entered : "+FirstName);
		//User input is in FirstName Do your check here if its correct or not
			if (string.Equals(FirstName, FirstNames[randomIndex], StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("You Win");
			}else{
				Console.WriteLine("You Lose");
			}
