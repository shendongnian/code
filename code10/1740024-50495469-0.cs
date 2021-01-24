    UserDetail user = new UserDetail
            {
                **UserRole = ctx.UserRole.Where(id => id.RoleID == 2).Select(r => r).FirstOrDefault(),**
                FirstName = usrInfo.FirstName,
                LastName = usrInfo.LastName,
                UserName = usrInfo.UserName,
                Password = usrInfo.Password,
                Email = usrInfo.Email,
            };
    _unitofwork.userDetail.Add(user);
    if (_unitofwork.Completed() > 0)
        return Request.CreateResponse(HttpStatusCode.OK, "Created");
    else
        return Request.CreateResponse()
