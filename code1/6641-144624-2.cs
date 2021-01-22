    using System;
    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AuthenticateUserService : System.Web.Services.WebService 
    {   
        [WebMethod]
        public bool AuthenticateUser(string username, string password) 
        {
            // Fake authentication for the example
            return (username == "jon" && password == "foobar");
        }
        
    }
