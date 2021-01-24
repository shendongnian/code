    var test = listASH
                              .Select(g => new
                              {
                                  SAMPLE_TIME = statiClass.By15Seconds(Convert.ToDateTime(g.SAMPLE_TIME)),
                                  WAIT_CLASS = g.WAIT_CLASS,
                                  COUNT = 0,
                              }).GroupBy(x => new { x.SAMPLE_TIME, x.WAIT_CLASS })
                              .Select(y => new list_TA
                              {
                                  SAMPLE_TIME = y.Key.SAMPLE_TIME,
                                  WAIT_CLASS = y.Key.WAIT_CLASS,
                                  COUNT = Math.Round(y.Count() / 15.0, 2),
                              }).ToList();
