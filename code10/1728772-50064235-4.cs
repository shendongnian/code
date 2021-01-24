    public static void PrettyPrint(string message, params (object, object)[] kvp)
    {
        Console.WriteLine(message);
        foreach (var (key, value) in kvp)
        {
            Console.Write(key + "\t\t\t" + value);
        }
    }
