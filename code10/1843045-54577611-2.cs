    IEnumerable<Interval> MergeAndList(IEnumerable<Interval> intervals) 
    {
    
    var ret = new List<Interval>(intervals);
    int lastCount=0;
    do
    {
        lastCount = ret.Count;
        ret = ret.Aggregate(new List<Interval>(),(agg, cur) =>
                    {
                        for (int i = 0; i < agg.Count; i++)
                        {
                            var a = agg[i];
							if(a.End.AddHours(1) >= cur.Start)
							{
							 agg[i] = new Interval{Start=a.Start, End=cur.End};
							 return agg;
							}
							else
							{
							 	agg[i] = new Interval{Start=a.Start, End=a.End};
							}
                        }
                        agg.Add(cur);
                        return agg;
                    });
    } while (ret.Count != lastCount);
    return ret;
    }
