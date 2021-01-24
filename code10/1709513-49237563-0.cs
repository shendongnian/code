    public static void Main()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("TheKeyString", "TheValueString");
        dict.Add("Water", "H2O");
        foreach (var entry in dict.Keys)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine(dict["Water"]);
    }
-
    output :>
    TheKeyString
    Water
    H2O
