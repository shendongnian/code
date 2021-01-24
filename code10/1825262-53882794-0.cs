      using System.Linq;
      ...
      // Temporal collection - list
      List<string> list = sResultarray1.ToList();
      // Downward - we don't want to check the inserted item
      for (int r = list.Count - 1; r >= 0; --r) {
        if (list[r] != null && list[r].Contains("WP") && list[r].Contains("CB")) {
          // if you want to insert - "shift and add duplicate value" - just insert
          list.Insert(r + 1, list[r]);
        }
      }
      // back to the array
      sResultarray1 = list.ToArray();
