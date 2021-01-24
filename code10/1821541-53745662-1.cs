    public IEnumerable<(DateTime, DateTime)> DateRangePerChunck
        (DateTime fromDate, DateTime toDate, int chunkSize)
    {
        var numberOfChunks = (toDate.Subtract(fromDate).Days +1 ) / chunkSize;
        for (int i = 0; i <= numberOfChunks; i++)
        {
            if (i == numberOfChunks)
            {
                yield return (fromDate.AddDays(chunkSize * i), toDate);
            }
            else
            {
                yield return (fromDate.AddDays(chunkSize * i), fromDate.AddDays((i + 1) * chunkSize - 1));
            }
        }
    }
