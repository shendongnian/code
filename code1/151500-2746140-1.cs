    // return 0, 2, 3, 6, 8
    var evens =
        Unfold(0, state => state < 10 ? Tuple.Create(state, state + 2) : null)
        .ToList();
    // returns 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
    var fibs =
        Unfold(Tuple.Create(0, 1), state => Tuple.Create(state.Item1, Tuple.Create(state.Item2, state.Item1 + state.Item2)))
        .Take(10).ToList();
