    var ans2 = myList.GroupBy(s => s.UserId)
                    .Select(sg => {
                        var ts = sg.Count();
                        var es = sg.Count(c => c.Status == Status.OK);
                        return new { TotalSamples = ts, EvaluatedSamples = es, PercentageRealized = 100.0 * ts / es };
                    });
