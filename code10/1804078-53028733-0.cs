    private List<OutputItem> GetOutput(DateTime start, DateTime end, List<OutputItem> specificRanges)
    {
        List<OutputItem> periods = new List<OutputItem>();
        foreach (OutputItem sr in specificRanges)
        {
            if (start >= sr.End && sr.Start <= end)
            {
                periods.Add(new OutputItem { Start = sr.Start, End = sr.End, Coeff = sr.Coeff });
            }
        }
        return periods;
    }
