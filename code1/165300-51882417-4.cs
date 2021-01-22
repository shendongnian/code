    static void Main(string[] args) 
    {
        Dictionary<string, string> dataDict = new Dictionary<string, string>();
        Console.Write("Enter your name: ");
        string n = Console.ReadLine();
        Console.Write("Enter your surname: ");
        string s = Console.ReadLine();
        dataDict.Add("Name", n)
        dataDict.Add("Surname", s)
        WriteDictToFile(dataDict, "PATH\\TO\\FILE");
    }
