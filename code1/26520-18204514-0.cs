    var input = new List<string> { "a", "g", "e", "w", "p", "s", "q", "f", "x", "y", "i", "m", "c" };
    var k = 3
    
    var res = Enumerable.Range(0, (input.Count - 1) / k + 1)
                        .Select(i => i * k)
                        .Select(i => input.GetRange(i, i + k > input.Count ? input.Count - i : k));
