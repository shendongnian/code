    var sequence = "ABCDE";
    var state = Initialize(sequence.Count(), 5);
    do
    {
        Console.WriteLine(new String(sequence.Where((_, idx) => state[idx]).ToArray()));
    }
    while (state.Next());
