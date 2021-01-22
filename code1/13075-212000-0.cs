    var grouped = new SortedDictionary<DateTime, List<TestClass>>();
    foreach (TestClass entry in testList) {
      DateTime date = entry.SomeTime.Date;
      if (!grouped.ContainsKey(date)) {
        grouped[date] = new List<TestClass>();
      }
      grouped[date].Add(entry);
    }
    foreach (KeyValuePair<DateTime, List<TestClass>> pair in testList) {
      Console.WriteLine("{0}: ", pair.Key);
      Console.WriteLine(BuildSummaryLine(pair.Value));
    }
