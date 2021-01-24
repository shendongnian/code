    using System;
    
    namespace WebApplication1
    {
        public partial class Default : System.Web.UI.Page
        {
            [System.Web.Services.WebMethod]
            public static string PostData(string text)
            {
                return text + DateTime.Now;
            }
        }
    }
