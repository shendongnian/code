    <%@ WebService Language="C#" Class="SampleWebService" %>
    using System;
    using System.Data;
    using System.Web;
    using System.Collections;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SampleWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string Hello()
        {
            return "Hello World!";
        }
        [WebMethod]
        public string DoStuff(out string stuff)
        {
            stuff = "Woohoo!";
            return "OK";
        }
    }
