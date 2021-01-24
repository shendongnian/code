	if(password.Length < 8)
	{
	    Console.WriteLine("Password length should be 8 symbols or more.");
	}
	if(!password.Any(x=>char.IsUpper(x)))
	{
	    Console.WriteLine("Password should contain at least one uppercase letter.");
	}
	if(!password.Any(x=>char.IsLower(x)))
	{
	    Console.WriteLine("Password should contain at least one lowercase letter.");		
	}
	if(!password.Any(x=>char.IsDigit(x)))
	{
	    Console.WriteLine("Password should contain at least one digit.");
	}
