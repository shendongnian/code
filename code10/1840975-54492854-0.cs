    var doubles = new List<double> { -1213123, 1345, -345, 1234535 };
    var strings = new List<string>();
    for (int i = 0; i < doubles.Count; i += 2)
    {
        strings.Add(doubles[i] + ", " + doubles[i + 1]);
    }
