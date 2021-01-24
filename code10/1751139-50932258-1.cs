	bool hasDigit = false;
	bool hasUpperCase = false;
	bool hasLowerCase = false;
	for (var i = 0; i < password.Length; ++i)
	{
		hasDigit = hasDigit || char.IsDigit(password[i]);
		hasUpperCase = hasUpperCase || char.IsUpper(password[i]);
		hasLowerCase = hasLowerCase || char.IsLower(password[i]);	
	}
	if(password.Length < 8)
	{
		Console.WriteLine("Password length should be 8 symbols or more.");
	}
	if(!hasUpperCase)
	{
		Console.WriteLine("Password should contain at least one uppercase letter.");
	}
	if(!hasLowerCase)
	{
		Console.WriteLine("Password should contain at least one lowercase letter.");
	}
	if(!hasDigit)
	{
		Console.WriteLine("Password should contain at least one digit.");
	}
