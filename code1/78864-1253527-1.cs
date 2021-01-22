    int conditions = 3;
    for (int c = 0; c < conditions; c++) {
        Console.WriteLine(
           "Condition {0} : {1}",
           (char)('A' + c),
           new String(
              Enumerable.Range(0, (1 << conditions))
              .Select(n => "TF"[(n >> c) & 1])
              .ToArray()
           )
        );
    }
