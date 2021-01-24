    public static int random_except_list_explicit(List<int> x) {
        // First, generate a list of possible answers by skipping the except positions in x
        var possibles = new List<int>();
        for (int i = 1; i <= 9; i++)
            if (!x.Contains(i))
                possibles.Add(i);
        // now pick a random member of the possible answers and return it
        return possibles[new Random().Next(0, possibles.Count)];
    }
