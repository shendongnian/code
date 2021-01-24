    var projectBydrivetimeList = ProjectbyDrivetime
                                 .GroupBy(v => new {v.Pid,v.JobEventType}) 
                                 .Select(g => new
                                 {
                                   Pid = g.Key.Pid,
                                   ProjectMinutes = g.Sum(x => x.JobMinutes),
                                   ProjectType=g.Select(x=> x.JobEventType).First()
                                  }).ToList();
