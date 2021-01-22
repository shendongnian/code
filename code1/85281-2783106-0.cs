    <%@ WebService Language="C#" Class="SimpleService" %>
    
    using System;
    using System.Web.Services;
    
    [System.Web.Script.Services.ScriptService]
    public class SimpleService : WebService
    {
        [WebMethod]
        public string GetMessage(string name)
        {
            return "Hello <strong>" + name + "</strong>, the time here is: " + DateTime.Now.ToShortTimeString();
        }
    } 
