    var userLogin = entities.ITPLUsers.firstOrDefault(e => e.Login == Login  
                & e.Password ==  EncryptedPassword;
    var empPersonal = entities.EmpPersonal.Where(....your condition...);
    if (UserLogin == null)
    {
       return Request.CreateErrorResponse(HttpStatusCode.NotFound)
    }
    else
    {
       return Request.CreateResponse(HttpStatusCode.OK,new {userlogin = UserLogin, empPersonal = empPersonal});
    }
