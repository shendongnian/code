    string inputString = "Hello, there| world";
    char[] splitChars = new char[]{',', '|'};
    		
  	foreach (string result in inputString.ExtendedSplit(splitChars))
    {
    	Console.WriteLine("'{0}'", result);
    }
