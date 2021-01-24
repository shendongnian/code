    var usersReportGroupList = (from log in dataContext.LookupScannedHistories
                                join user in dataContext.UserMasters
                                on log.UserID equals user.UserId 
                                where log.ScannedDate >= fiveDayPriorDate
                                orderby log.ScannedDate
                                 group new { user.UserName, log.ScannedCount, 
                                  log.ScannedDate} 
                                                    
                                  by new
                                  {
                                   ScannedDateOnly = 
                                 EntityFunctions.TruncateTime(log.ScannedDate),
                                 log.UserID,
                                 user.UserName
                                 } 
                                 into dateClickedHistory
                                  select dateClickedHistory                                              
                                 ).ToList();
       var usersReportList = new List<LookupScannedHistoryDetails>();
                        foreach (var group in usersReportGroupList)
                        {
                            usersReportList.Add(new LookupScannedHistoryDetails()
                            {
                                ScannedCount = group.Sum(x => x.ScannedCount.Value),
                                ScannedDate = group.Key.ScannedDateOnly.Value,
                                UserId = group.Key.UserID.Value,
                                UniqueCount = group.Count(),
                                UserName = group.Key.UserName
                            });
                        }
