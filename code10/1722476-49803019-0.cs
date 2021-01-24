    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Diagnostics;
    
    namespace Performance_Dashboard.Controllers
    {
    public class GetLoggedInData
    {
        public string ActualUser { get; internal set; }
    
        public string GetLoggedInDataofUser()
        {
           ActualUser= HttpContext.Current.User.Identity.Name;
           Debug.Write(ActualUser);
           return ActualUser;
        }
      }
    }
