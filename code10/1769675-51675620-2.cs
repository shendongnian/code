       db.AspNetUsers.Select(i => new UserElementDomain()
                    {
                        UserId = i.Id,
                        CompanyName = i.Company.Name,
                        FirstName = i.AspNetUserProfile?.FirstName,
                        LastName = i.AspNetUserProfile?.LastName,
                        RoleName = i.AspNetRoles.FirstOrDefault().Name,
                        SMSnumber = i.SMSnumber,
                        UserName = i.UserName,
                        .....
                    })
