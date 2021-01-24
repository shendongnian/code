    static void Main()
    {
    	TextInfo info = CultureInfo.CurrentCulture.TextInfo;
    	string input = "some lowercase text";
    	Console.WriteLine(info.ToTitleCase(input)); // Outputs 'Some lowercase text'
    	Console.ReadKey(true);
    }
