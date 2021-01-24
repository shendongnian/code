    static void TestRegex()
    {
    	string name = "AL QADEER UR AL REHMAN AL KHALIL UN";
    	// Add other strings you want to remove
    	string pattern = @"\b(AL|UR|UN)\b";
    	name = Regex.Replace(name, pattern, String.Empty);
    	// Remove extra spaces
    	name = Regex.Replace(name, @"\s{2,}", " ").Trim();
    	Console.WriteLine(name);
    }
