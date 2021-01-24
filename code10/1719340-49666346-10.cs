    var input = new[] { 1, 2, 3, 3, 4, 5, 5, 5, 6, 6, 5, 4, 4, 3, 2, 1, 6 };
    var result = input.ToObservable()
                      .DistinctUntilChanged()
                      .ToEnumerable()
                      .ToArray();
