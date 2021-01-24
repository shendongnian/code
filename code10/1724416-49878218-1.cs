      if (missingEntry == 1)
                {
                    Pair missingPair = new Pair();
                    var missingLog = db.AttendanceLogs.Where(x => x.RegisterationId == EnrollNumber && x.Date >= StartDate &&
                  x.Date <= EndDate && x.isIgnore != true).OrderByDescending(x => x.DateTime).FirstOrDefault();
                    if (missingLog.CheckType == "In")
                    {
                        missingPair.InnDateTime = missingLog.DateTime;
                        missingPair.OutDateTime = missingLog.DateTime.AddMinutes(1);
                        pairList.Add(missingPair);
                        return pairList;
                    }
                    else
                    {
                        return pairList;
                    }
                }
