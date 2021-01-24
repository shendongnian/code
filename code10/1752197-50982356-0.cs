    IEnumerable<DateTime> Split(DateTime start, DateTime end, int minutes)
    {
        if (minutes == 0)
            throw new ArgumentException(
                $"'{nameof(minutes)}' should be greater than 1 minute.",
                nameof(minutes));
        var result = start;
        while (result <= end)
        {
            yield return result;
            result = result.AddMinutes(minutes);
        }
    }
