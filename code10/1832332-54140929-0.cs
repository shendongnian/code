    <%@ WebService language = "C#" class = "NotifyService" %>
    
    using System;
    using System.Web.Services;
    using System.Xml.Serialization;
    
    [WebService(Namespace = "http://localhost/")]
    public class NotifyService: WebService{
    
       [WebMethod]
       [ScriptMethod(UseHttpGet = true)]
       public String Notify() 
       {
          return "OK";
       }
    }
