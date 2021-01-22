    int[,] foo = new int[2, 3]
    {
      {1,2,3},
      {4,5,6}
    };
    
    int[] first = Enumerable.Range(0, foo.GetLength(0))
                            .Select(i => foo[i, 0])
                            .ToArray();
    // first == {1, 4}
