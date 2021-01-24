    int[] items = { 1, 2, 3, 7, 8, 9, 13, 16, 19, 23, 25, 26, 29, 31, 35, 36, 39, 45 };
    int[] indices = { 1, 3, 5, 6, 7, 9 };
    int[] result = indices
      .Select(index => items[index])
      .ToArray();
