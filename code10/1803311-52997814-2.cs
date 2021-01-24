    int numberOfReviewers = 3;
    var stopWatch = Stopwatch.StartNew();
    var reviewers = GetReviewerIds(@"ratings.json")
        .GroupBy(x => x)
        .Select(x => new
        {
            Id = x.Key,
            Count = x.Count()
        })
        .OrderByDescending(x => x.Count)
        .Take(numberOfReviewers)
        .ToList();
    stopWatch.Stop();
    Console.WriteLine($"Reviewer with ID {reviewers.First().Id} has done {reviewers.First().Count} reviews; Execution time: {stopWatch.Elapsed:g}");
