    static void Main(string[] args)
    {
    	//Encoding _UTF8 = Encoding.UTF8;
    	string[] _mainString = { "Héllo World" };
    	Console.WriteLine("Main String: " + _mainString);
    
    	//Convert a string to utf-8 bytes.
    	byte[] _utf8Bytes = Encoding.UTF8.GetBytes(_mainString[0]);
    
    	//Convert utf-8 bytes to a string.
    	string _stringuUnicode = Encoding.UTF8.GetString(_utf8Bytes);
    	Console.WriteLine("String Unicode: " + _stringuUnicode);
    }
