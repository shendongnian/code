    using System.Security.Principal;
    
    [WebMethod()]
    public string userName()
    {
        return User.Identity.Name.ToString();
    }
