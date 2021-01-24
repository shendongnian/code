    // 1: Count of all units
    var count = units.Count();
    Console.WriteLine($"Count {count}"); // Count 5
    // 2: Sum of all units scored marks and total marks:
    var sumScoredMarks = units.Sum(u => u.ScoredMarks);
    var sumTotalMarks = units.Sum(u => u.TotalMarks);
    Console.WriteLine($"Sum scored {sumScoredMarks} | Sum total {sumTotalMarks}"); // Sum scored 320 | Sum total 500
    // 3. Average scoredMarks%Totalmarks*100
    var average = units.Average(u => u.ScoredMarks % u.TotalMarks * 100);
    Console.WriteLine($"Average {average}"); // Average 6400
    // 4. Rank based on score
    var ranked = _units.GroupBy(u => u.UserID)
        .OrderByDescending(g => g.Average(u => u.ScoredMarks / u.TotalMarks * 100))
        .Select((g, i) => $"{i + 1}. {g.Key} ({g.Average(u => u.ScoredMarks / u.TotalMarks * 100)})");
    Console.WriteLine("Ranked: \n" + string.Join("\n", ranked));
    /*
    Ranked:
    1. 1022 (77.5)
    2. 1021 (51.66667)
    */
