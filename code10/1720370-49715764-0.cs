    public static IEnumerable<string> FindAllCombinations()
    {
        List<int> ListOne = Enumerable.Range(1, 100).ToList();
        List<int> ListTwo = Enumerable.Range(1, 100).ToList();
        var result = from a in ListOne
                     from b in ListTwo
                     let condition = a.CompareTo(b)
                     where condition != 0
                     select condition < 0 ? a + "-" + b : b + "-" + a;
        var allCombinations = result.Distinct();
        ICollection<string> finalCombinations = new List<string>();
        foreach (string combination in allCombinations)
        {
            var splitted = combination.Split('-');
            finalCombinations.Add($"A{splitted[0]}B{splitted[1]}");
        }
        return finalCombinations;
    }
