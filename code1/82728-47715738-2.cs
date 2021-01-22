    public static void MyFunction(params (string Key, object Value)[] pairs)
    {
        foreach (var pair in pairs) {
            Console.WriteLine($"{pair.Key} = {pair.Value}");
        }
    }
