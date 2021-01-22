        public static class ErrorHelper
    {
        /// <summary>
        /// Manually log an exception to Elmah.  This is very useful for the agents that try/catch all the errors.
        /// 
        /// In order for this to work elmah must be setup in the web.config/app.config file
        /// </summary>
        /// <param name="ex"></param>
        public static void LogErrorManually(Exception ex)
        {
            if (HttpContext.Current != null)//website is logging the error
            {                
                var elmahCon = Elmah.ErrorSignal.FromCurrentContext();
                elmahCon.Raise(ex);
            }
            else//non website, probably an agent
            {                
                var elmahCon = Elmah.ErrorLog.GetDefault(null);
                elmahCon.Log(new Elmah.Error(ex));
            }
        }
    }
