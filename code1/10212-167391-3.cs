    List<string> strings = new List<string>();
    strings.Add("Good");
    strings.Add("Morning")
    strings.Add("Starshine");
    strings.Add("The");
    strings.Add("Earth");
    strings.Add("says");
    strings.Add("hello");
    private static bool FindHello(String s)
    {
        return s == "hello";
    }
    strings.Find(FindHello);
