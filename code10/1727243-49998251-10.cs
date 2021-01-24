    public void Add(int i)
    {
        // is it within or contiguous to an existing range
        foreach(var range in ranges)
        {
            if(i>=range.Start && i<=range.End)
                return; // already in a range
            if(i == range.Start-1)
            {
                range.Update(i,range.End);
                return;
            }
            if(i == range.End + 1)
            {
                range.Update(range.Start,i);
                return;
            }
        }
        // not in any ranges
        ranges.Add(i);
    }
