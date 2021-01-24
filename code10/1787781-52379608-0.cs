    public static Boolean CheckCode(String strInput)
    {
        if (strInput.Length < 4 || strInput.Length > 6)
        {
            Console.Write("Please enter a valid code, 4 to 6 characters, letters only." + "\n");
            return false;
        }
        else
        {   //make sure that input is letters only
            return Regex.IsMatch(strInput, @"^[a-zA-Z]+$");
        }
    }
