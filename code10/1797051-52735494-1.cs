    List<string> names = new List<string>() { "a", "b", "c" };
    IEnumerable<string> skip2 = names.Skip(2);
    Console.WriteLine(string.Join(", ", skip2)); // "c"
    names.Add("d");
    names.Add("e");
    Console.WriteLine(string.Join(", ", skip2)); // "c, d, e"
