        var dates = new List<DateTime> 
                    { 
                        new DateTime(2010, 1, 1), 
                        new DateTime(2010, 2, 1), 
                        new DateTime(2010, 3, 1) 
                    };
        var intervals = dates.Aggregate(new List<Interval>(), (ivls, d) =>
            {
                if (ivls.Count != dates.Count-1)
                {
                    ivls.Add(new Interval(d,dates[ivls.Count + 1]));
                }
                return ivls;
            });
