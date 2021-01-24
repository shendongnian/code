    private static List<string> Acc = new List<string>();
    public static string[] GetAccounts()
    {
        return Acc.ToArray();
    }
    public static void AddAccount(string value)
    {
        Acc.Add(value)
    }
