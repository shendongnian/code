    using System.Linq;
    ...
    private static IEnumerable<int[]> Generate(int width) {
      int[] item = new int[width];
      while (true) {
        yield return item.ToArray(); // .ToArray() - return a copy of the item
        int[] next = new int[width];
        for (int i = 1; i < item.Length - 1; ++i) 
          if (item[i - 1] == item[i] && item[i] == item[i + 1])
            next[i] = 1;
        item = next;
      }
    }
