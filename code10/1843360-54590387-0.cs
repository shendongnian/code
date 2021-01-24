    	DateTime today = DateTime.Today;
        Console.WriteLine("Type your birthday: ");
		DateTime b = DateTime.Parse(Console.ReadLine());
		
		TimeSpan age = (today - b);
		double final = age.TotalDays / 365.2425;
		Console.WriteLine("You have" + final + "years");
