    public List<Pair> getSingleDevicePairs(int EnrollNumber, DateTime StartDate, DateTime EndDate, int? missingEntry)
    {
        var logs = db.AttendanceLogs.Where(x => x.RegisterationId == EnrollNumber && 
                   x.Date >= StartDate && x.Date <= EndDate && x.isIgnore != true 
                   && (x.CheckType == "In" || x.CheckType == "Out")).Distinct().ToList();
    
                if (logs.Count > 0)
                {
                    bool isCheck = false;
                    Pair pair = new Pair();
                    DateTime previous = logs.FirstOrDefault().DateTime;
    
                    foreach (var log in logs)
                    {
                        if (!isCheck)
                        {
                            if (log.CheckType == "In")
                            {
                                pair.InnDateTime = log.DateTime;
                                isCheck = true;
                            }
                        }
                        else
                        {
                            if (log.CheckType == "Out")
                            {
                                pair.OutDateTime = log.DateTime;
                                isCheck = false;
                                pairList.Add(pair);
                                pair = new Pair();
    
                            }
                            if (pair.OutDateTime == DateTime.MinValue)
                            {
                                pair.InnDateTime = log.DateTime;
                            }
    
                        }
                    }
                }
                return pairList;
            }
