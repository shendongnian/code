    private static IEnumerable<Tuple<DateTime, DateTime>> Accumulate(
      IEnumerable<Tuple<DateTime, DateTime>> source) {
      var data = source
        .OrderBy(date => date.Item1)
        .ThenByDescending(date => date.Item2);
      DateTime left = DateTime.MinValue;  // make compiler be happy: initialization
      DateTime right = DateTime.MinValue; // -/-
      bool first = true;
      foreach (var item in data) {
        if (first) {
          left = item.Item1;
          right = item.Item2;
          first = false;
        }
        else if (right.AddDays(1) >= item.Item1) // can be combined; keep on combining
          right = item.Item2 > right ? item.Item2 : right;
        else {
          // can't be combined: return previous chunk
          yield return Tuple.Create(left, right);
          // start a new chunk
          left = item.Item1;
          right = item.Item2;
        }
      }
      // if we have a very last chunk to return, do it
      if (!first)
        yield return Tuple.Create(left, right);
    }
