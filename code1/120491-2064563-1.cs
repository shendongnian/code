    <%@ WebService Language="C#" Class="MyWebService" %>
    
    using System;
    using System.Web;
    using System.Web.Services;
    
    [WebService(Namespace = "http://www.example.com/webservices/MyWebService, Description = "My Web Service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MyWebService : WebService
    {
        [WebMethod(Description = "Add two numbers and return the result.")]
	public int AddNumbers(int first, int second) {
            return first + second;
	}
    }
