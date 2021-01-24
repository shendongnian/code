    Regex durationFinder = new Regex(@"Duration: (?<duration>(\d{2}:\d{2}:\d{2}.\d{2}))");
    Regex timeFinder = new Regex(@"time=(?<time>(\d{2}:\d{2}:\d{2}.\d{2}))");
    TimeSpan inputDuration = TimeSpan.MinValue;
    TimeSpan currentTime = TimeSpan.MinValue;
    double percentageCompletion = 0.0;
    while ((processOutput = _process.StandardError.ReadLine()) != null)
    {
        var durationMatch = durationFinder.Match(processOutput);
        if (durationMatch.Success)
        {
            var duration = durationMatch.Groups["duration"];
            TimeSpan.TryParse(duration.Value, out inputDuration);
        }
        var timeMatch = timeFinder.Match(processOutput);
        if (timeMatch.Success)
        {
            var time = timeMatch.Groups["time"];
            TimeSpan.TryParse(time.Value, out currentTime);
        }
        if (currentTime != TimeSpan.MinValue && inputDuration != TimeSpan.MinValue)
            percentageCompletion = (currentTime.Ticks / (double)inputDuration.Ticks);
    }   
