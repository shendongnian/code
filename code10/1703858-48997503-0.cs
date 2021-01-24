    var TestTable = new[] {
        new { Id = 1, Start = 1, End = 1 },
        new { Id = 2, Start = 1, End = 2 },
        new { Id = 3, Start = 2, End = 5 },
        new { Id = 4, Start = 2, End = 1 },
        new { Id = 5, Start = 3, End = 2 },
    };
    var TestSet1 = new[] { 1, 2 };
    var ans1 = TestTable.GroupBy(tt => tt.Start)
                        .Select(ttg => new { Start = ttg.Key, Ends = ttg.Select(tt => tt.End).ToList() })
                        .Any(StartEnds => TestSet1.All(testEnd => StartEnds.Ends.Contains(testEnd)));
    // ans1 is true
    var TestSet2 = new[] { 1, 2, 5 };
    var ans2 = TestTable.GroupBy(tt => tt.Start)
                        .Select(ttg => new { Start = ttg.Key, Ends = ttg.Select(tt => tt.End).ToList() })
                        .Any(StartEnds => TestSet2.All(testEnd => StartEnds.Ends.Contains(testEnd)));
    // ans2 is false
