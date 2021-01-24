	public static void Main()
	{
        //defined in outer scope        
		string customPath = string.Empty;
		do
        {
			Console.WriteLine("If you are using a different download path for your mods enter (Y)es. Or if you want to exit out the program enter (N)o!");
            //Calling ToUpper() before assigning the value to customPath
			customPath = Console.ReadLine().ToUpper();
		}
		while (customPath != "N" || customPath != "Y");
	}
