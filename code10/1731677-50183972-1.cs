    IEnumerable<List<string> GetPermutationsList(List<string> items, int count)
    {
        return GetPermutations(items, count).Select(x=>x.ToList())
    }
    IEnumerable<List<string>> permutationLists = GetPermutations(ingredientList.AsEnumerable(), ingredientList.Count);
    // or
    List<List<string>> permutationLists = GetPermutations(ingredientList.AsEnumerable(), ingredientList.Count).ToList();
