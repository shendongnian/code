    var dict = new Dictionary<double, int>{
        [doubleTuple] = intTuple,
        [5000.00] = 2,
        [5000.25] = 3,
        [5000.50] = 4,
        [5000.25] = 5
    }
    if (dict.TryGetValue(5000.25, out int result)) {
        ...
    }
