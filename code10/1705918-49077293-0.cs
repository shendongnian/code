    Dictionary<int, string> s = new Dictionary<int, string>();
    var types = typeof(int).Assembly.GetTypes();
    Console.WriteLine($"Inspecting {types.Length} types...");
    foreach (var t in typeof(-put a type from that assembly here-).Assembly.GetTypes())
    {
        if (s.ContainsKey(t.GetHashCode()))
        {
            Console.WriteLine($"{t.Name} has the same hashcode as {s[t.GetHashCode()]}");
        }
        else
        {
            s.Add(t.GetHashCode(), t.Name);
        }
    }
    Console.WriteLine("done!");
