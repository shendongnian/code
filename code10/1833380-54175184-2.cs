    // Pretend we got these from the database
    DateTime date = DateTime.Parse("01/16/2019");
    DateTime startTime = DateTime.Parse("2:00 PM");
    DateTime endTime = DateTime.Parse("3:00 PM");
    // Interview length in minutes
    int interviewLength = 15;
    // Get a list of 15 minute increments starting at start time
    List<DateTime> increments =
        Enumerable.Range(0, (int) (endTime - startTime).TotalMinutes / interviewLength)
            .Select(minutes => startTime.AddMinutes(minutes * interviewLength))
            .ToList();
    // Show results to console
    Console.WriteLine($"Start times available on {date.ToShortDateString()}:");
    increments.ForEach(time => Console.WriteLine($"\t{time.ToShortTimeString()}"));
    Console.ReadKey();
