    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace TEClaim.Models
    {
    public class LogedinUserDetails
    {
        public string UserID { get; set; }
        public string UserRole { get; set; }
        public string UserSupervisor { get; set; }
        public LogedinUserDetails()
        {
        }
        public static LogedinUserDetails Singleton()
        {
            LogedinUserDetails oSingleton;
            if (null == System.Web.HttpContext.Current.Session["LogedinUserDetails"])
            {               
                oSingleton = new LogedinUserDetails();
                System.Web.HttpContext.Current.Session["LogedinUserDetails"] = oSingleton;
            }
            else
            {              
                oSingleton = (LogedinUserDetails)System.Web.HttpContext.Current.Session["LogedinUserDetails"];
            }
            //Return the single instance of this class that was stored in the session
            return oSingleton;
        }
    }
    }
