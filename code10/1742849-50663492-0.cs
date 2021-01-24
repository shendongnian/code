        [System.Web.Services.WebMethod]
        public static string GetTime()
        {
            return System.DateTime.Now.ToString();
        }
