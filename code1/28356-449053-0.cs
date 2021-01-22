    return classQuery.Select(p => new SelectClassData
                                  {
                                       ClassID = p.ClassID,
                                       Title = p.Title,
                                       sDate = p.StartDate,
                                       eDate = p.EndDate
                                  }).ToList();
