    List<int> input = new List<int> { 1, 3, 3, 4 };
    var dictionary = new Dictionary<int, int>();
    var index = 1;
    foreach (var n in input.Distinct().OrderBy(n => n)) {
        dictionary.Add(n, index++);
    }
    var output = input.Select(n => dictionary[n]);
