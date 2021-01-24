        var UserInfo = (from UserDetail in _userDBContext.UserDetails
                        join doc in _userDBContext.Documents 
                        on UserDetail.Id equals doc.UserIdFK
                        select new
                        {
                            UserId = UserDetail.Id,
                            DoB = UserDetail.DoB,
                            Name = UserDetail.Name,
                            DocId = doc.Id,
                            doc.UserIdFK,
                            doc.ImagePath
                        }).ToList();
