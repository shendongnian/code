    public Number Rand()
    {
    
    	byte[] Salt = new byte[8];
    
    	System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(Salt);
    
    	decimal result = 0;
    
    	foreach (byte b in Salt)
	{
		result = result * 255 + b;
	}
	while (result > 100)
	{
		result /= 10;
	}
	return result
}
