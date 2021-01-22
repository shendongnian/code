    DateTime startTime = DateTime.Now;
    for (int index = 0, count = lines.Count; index < count; index++) {
        // Do the processing
        ...
        // Calculate the time remaining:
        TimeSpan timeRemaining = TimeSpan.FromTicks(DateTime.Now.Subtract(startTime).Ticks * (count - (index+1)) / (index+1));
        // Display the progress to the user
        ...
    }
