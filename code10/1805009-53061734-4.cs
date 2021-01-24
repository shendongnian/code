    if (pager != null)
                {
                    var totalRecords = query.Count();
                    pager.TotalRecords = totalRecords;
                    var data = query.Select(x =>
                        new AuditInfo
                        {
                            TypeFullName = x.audit.TypeFullName,
                            UserName = x.audit.UserName,
                            EventType = x.audit.EventType,
                            EventDateUTC = x.audit.EventDateUTC,
                            LogDetails = x.audit.LogDetails.ToList(),
                            Name = x.entaudits.Name,
                            Description = x.entaudits.Description
                        })
                        .OrderByDescending(x => x.EventDateUTC)
                        .Skip(pager.From)
                        .Take(pager.PageSize);
                    try
                    {
                        var list1 = data.ToList<AuditInfo>();
                    }
                    catch (Exception e)
                    {
                    }
                    var list = data.ToList<AuditInfo>();
                    pager.RecordCount = list.Count;
                    return list;
                }
                else
                {
                    var list = query.Select(x =>
                        new AuditInfo
                        {
                            TypeFullName = x.audit.TypeFullName,
                            UserName = x.audit.UserName,
                            EventType = x.audit.EventType,
                            EventDateUTC = x.audit.EventDateUTC,
                            LogDetails = x.audit.LogDetails.ToList(),
                            Name = x.entaudits.Name,
                            Description = x.entaudits.Description
                        })
                            .OrderByDescending(x => x.EventDateUTC)
                        .ToList<AuditInfo>();
                    return list;
                }
