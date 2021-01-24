    var ansd = myList.GroupBy(s => s.UserId)
                     .Select(sg => {
                         var ts = sg.Count();
                         var es = sg.Count(c => c.Status == Status.OK);
                         return new { sg.Key, ts, es };
                     })
                     .ToDictionary(ste => ste.Key, ste => new DtoTest {
                        UserId = ste.Key,
                        TotalSamples = ste.ts,
                        EvaluatedSamples = ste.es,
                        PercentageRealized = (int)(100.0 * ste.ts / ste.es) });
    var ans4 = myList.Select(s => ansd[s.UserId]);
