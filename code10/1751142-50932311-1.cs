	static void Main(string[] args)
	{
		var password = Console.ReadLine();
		bool passwordCorrect = false;
		
		while (!passwordCorrect)
		{
			bool hasDigit = false;
			bool hasUpperCase = false;
			bool hasLowerCase = false;
			
			for (var i = 0; i < password.Length; ++i)
			{
				if (char.IsDigit(password[i]))
					hasDigit = true;
				
				if (char.IsUpper(password[i]))
					hasUpperCase = true;
				
				if (char.IsLower(password[i]))
					hasLowerCase = true;
			}
			
            if (password.Length >= 8 
                && hasUpperCase 
                && hasLowerCase 
                && hasDigit)
            {
                passwordCorrect = true;
            }
            else
            {
			    if(password.Length < 8)
				    Console.WriteLine("Password length should be 8 symbols or more.");
			
			    if(!hasUpperCase)
				    Console.WriteLine("Password should contain at least one uppercase letter.");
			
			    if(!hasLowerCase)
				    Console.WriteLine("Password should contain at least one lowercase letter.");
			
			    if(!hasDigit)
				    Console.WriteLine("Password should contain at least one digit.");
			
			    password = Console.ReadLine();
            }
		}
		
		Console.WriteLine("Your password is properly set!");
		Console.ReadLine();
	}
