    Dictionary<string, List<string>> vertices = new Dictionary<string, List<string>>();
    vertices.Add("B", new List<string> { "N", "P" });
    vertices.Add("N", new List<string> { "B", "S" });
    vertices.Add("S", new List<string> { "N" });
    vertices.Add("P", new List<string> { "X", "Y", "U", "I", "R" });
    vertices.TryGetValue("P", out List<string> value);
    foreach (string s in value)
    {
        Console.Write(s + ",");
    }
