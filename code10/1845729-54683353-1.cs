    var list = dbcontext.StudentProfiles.GroupBy(u => u.CreatedDate.Value.Month)
                    .Select(group => new UserData
                    {
                        Month = group.Key.ToString(),
                        UserCount = group.Count()
                    }).ToList();
