     UserDetail user = new UserDetail
                {
                    UserRole = _unitofwork.UserRole.Where(id => id.RoleID == 2).Select(r => r).FirstOrDefault(),
                    FirstName = usrInfo.FirstName,
                    LastName = usrInfo.LastName,
                    UserName = usrInfo.UserName,
                    Password = usrInfo.Password,
                    Email = usrInfo.Email,
                };
        _unitofwork.userDetail.Add(user);
