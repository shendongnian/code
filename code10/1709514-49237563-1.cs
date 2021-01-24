    public static void Main()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("TheKeyString", "TheValueString");
        dict.Add("Water", "H2O");
        foreach (var entry in dict.Keys)
        {
            Console.WriteLine($"Key: {entry}");
        }
        Console.WriteLine($"Value: {dict["Water"]}");
    }
-
    output :>
    Key: TheKeyString
    Key: Water
    Value: H2O
