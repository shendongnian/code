     public static void Main(string[] args)
    {
        var list1 = new List<string> { "br", "je" };
        var list2 = new List<string> { "banana", "bread", "jam", "brisket", "flakes", "jelly" };
        var result = string.Join(",",ContainsValues(list1, list2));
        Console.WriteLine($"{string.Join(",",list1)}");
        Console.WriteLine($"{string.Join(",", list2)}");
        Console.WriteLine($"{result}");
        Console.Read();
        IEnumerable<bool> ContainsValues(List<string> lst1, List<string> lst2) =>
          lst2.Select(l2 => lst1.Any(l1 => l2.IndexOf(l1, StringComparison.OrdinalIgnoreCase) >= 0));
    }   
    
    `
`
