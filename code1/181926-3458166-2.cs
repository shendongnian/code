    string myString = "\\Mesg";
    Console.WriteLine(myString); // Returns: \Mesg
    Console.WriteLine(EscapeSlashes(myString)); //Returns; \\Mesg
    
    public static string EscapeSlashes(string str)
    {
    	return str.Replace("\\", "\\\\");
    }
