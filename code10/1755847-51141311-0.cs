    /// <summary>
    /// Returns a timespan from an input string that specifies minutes:seconds.milliseconds
    /// </summary>
    /// <param name="input">"minutes:seconds.milliseconds"</param>
    /// <returns>Timespan representation of the input string</returns>
    private static TimeSpan ParseMinSecMS(string input)
    {       
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("input cannot be null, empty, or whitespace");
        var minutes = 0;
        var seconds = 0;
        var milliseconds = 0;
        // Split the string into minutesSeconds / milliseconds
        var minSecMS = input.Split('.');
        // If there was a period in the result, then the part after it is milliseconds
        if (minSecMS.Length > 1) int.TryParse(minSecMS[1], out milliseconds);
        // Split the minutesSeconds into minutes / seconds
        var minSec = minSecMS[0].Split(':');
        // If there was a colon in the result, then the first  
        // part is minutes and the second part is seconds
        if (minSec.Length > 1)
        {
            int.TryParse(minSec[0], out minutes);
            int.TryParse(minSec[1], out seconds);
        }
        // Otherwise it is just seconds
        else
        {
            int.TryParse(minSec[0], out seconds);
        }
        // Use these values to construct a new timespan
        return new TimeSpan(0, 0, minutes, seconds, milliseconds);
    }
