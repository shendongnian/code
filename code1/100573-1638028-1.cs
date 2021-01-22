    DateTime lastGroupDate = DateTime.MinValue;
    DateTime lastDate = DateTime.MinValue;
    IEnumerable<IGrouping<DateTime, MyObj>> groups = myList
        .GroupBy(o =>
            {
                if (lastGroupDate != DateTime.MinValue &&
                    o.Date.AddDays(-1) == lastDate)
                {
                    lastDate = o.Date;
                }
                else
                {
                    lastGroupDate = o.Date;
                    lastDate = o.Date;
                }
                return lastGroupDate;
            }
        );
    foreach(IGrouping<DateTime, MyObj> grouping in groups)
    {
        // grouping.Key == the grouped date / first in sequence
        foreach(MyObj obj in grouping)
        {
            // obj.Date == actual date
        }
    }
