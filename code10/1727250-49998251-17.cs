    private void SortAndMerge()
    {
        ranges.Sort((a,b) => a.Start - b.Start);
        var i = ranges.Count-1;
        do
        {
            var start = ranges[i].Start;
            var end = ranges[i-1].End;
            if(end == start-1)
            {
                // merge and remove
                ranges[i-1].Update(ranges[i-1].Start,ranges[i].End);
                ranges.RemoveAt(i);
            }
        } while(i-- >1);
    }
