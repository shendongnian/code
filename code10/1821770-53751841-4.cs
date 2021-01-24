    var ans2 = myList.GroupBy(s => s.UserId)
                    .Select(sg => {
                        var ts = sg.Count();
                        var es = sg.Count(c => c.Status == Status.OK);
                        return new DtoTest { UserId = sg.Key, TotalSamples = ts, EvaluatedSamples = es, PercentageRealized = (int)(100.0 * ts / es) };
                    });
