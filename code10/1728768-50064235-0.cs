    public static void PrettyPrint(string message, params (object key, object value)[] kvp)
    {
        Console.WriteLine(message);
        foreach (var p in kvp)
        {
            Console.Write(p.key + "\t\t\t" + p.value);
        }
    }
