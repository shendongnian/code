    public void YourMethod()
    {
        var rss = result.Select(x => new RssData { x.SampleDate, x.DataValue })
                  .OrderBy(a => a.SampleDate).ToList(); // .ToList() may be redundant here as the foreach below will force the iteration, but that's not really the point of this. :)
        foreach(var r in rss)
        {
            if(r.SampleDate.HasValue)
                r.SampleDate = r.SampleDate.Value.AddMilliseconds(1);
        }
    }
