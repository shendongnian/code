    var Temp_DT = tempdt.AsEnumerable().Select(x =>
                        new
                        {
                            UID = x["UID"],
                            EMPNAME = x["Emp Name"],
                            EMPROLE = x["Role"],
                            SUPID = x["Sup ID"],
                            SUPNAME = x["Sup Name"],
                            DESIGNATION = x["Designation"],
                            VOLUME = x["Volume"],
                            ERRORTIME = x["Error_Time"],                            
                            ACWTIME = x["ACW"],
                            BREAKTIME = x["Break Time"],
                            IDLETIME = x["Idle"],
                            NONPRODUCTIVE = x["Non Productive"],
                        }).GroupBy(s => new { s.UID, s.EMPNAME, s.EMPROLE, s.SUPID, s.SUPNAME, s.DESIGNATION })
                        .Select(g => {
                          var grouped = g.ToList();
                        return new
                        {
                            UID = g.Key.UID,
                            EMPNAME = g.Key.EMPNAME,
                            EMPROLE = g.Key.EMPROLE,
                            SUPID = g.Key.SUPID,
                            SUPNAME = g.Key.SUPNAME,
                            DESIGNATION = g.Key.DESIGNATION,
                            VOLUME = grouped.Sum(x => Convert.ToInt16(x.VOLUME)),
                            Error_Time = new TimeSpan(grouped.Select(x => ConvertTimeSpan(x.ERRORTIME.ToString())).ToList().Sum(r=> r.Ticks)),
                            ACW = new TimeSpan(grouped.Select(x => ConvertTimeSpan(x.ACWTIME.ToString())).ToList().Sum(r=> r.Ticks)),
                            Break = new TimeSpan(grouped.Select(x => ConvertTimeSpan(x.BREAKTIME.ToString())).ToList().Sum(r=> r.Ticks)),
                            Idle = new TimeSpan(grouped.Select(x => ConvertTimeSpan(x.IDLETIME.ToString())).ToList().Sum(r=> r.Ticks)),
                            NonProductive = new TimeSpan(grouped.Select(x => ConvertTimeSpan(x.NONPRODUCTIVE.ToString())).ToList().Sum(r=> r.Ticks))
                        };
                        }).ToList();
