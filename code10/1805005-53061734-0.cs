    var data = query.Select(x =>
                    new ClassName
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
    
    var list = data.ToList<ClassName>();
