    public static void PrettyPrint(string message, object kvp) {
        if (kvp == null)
            return;
        Console.WriteLine(message);
        foreach (var p in kvp.GetType().GetProperties()) {
            Console.Write(p.Name + "\t\t\t" + p.GetValue(kvp));
        }
    }
