        foreach (string value in GetCombinations(
              "A", "B", "C", "D", "E", "F", "G", "H")
            .OrderBy(s=>s.Length)
            .ThenBy(s=>s))
        {
            Console.WriteLine(value);
        }
