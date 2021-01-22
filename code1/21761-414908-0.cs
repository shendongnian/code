    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;
    
    namespace BDZipper.Site
    {
        /// <summary>
        /// This class maintains all session variables for us instead of handeling them 
        /// individually in the session.  They are also strongly typed.
        /// </summary>
        public static class SessionManager
        {
    
            # region Private Constants
            // Define string constant for each property.  We use the constant to call the session variable
            // easier not to make mistakes this way.
            // I think for simplicity, we will use the same key string in the web.config AppSettings as
            // we do for the session variable.  This way we can use the same constant for both!
            private const string startDirectory = "StartDirectory";
            private const string currentDirectory = "CurrentDirectory";
    
            # endregion
    
            /// <summary>
            /// The starting directory for the application
            /// </summary>
            public static string StartDirectory
            {
                get
                {
                    return GetSessionValue(startDirectory, true);
                }
                //set
                //{
                //    HttpContext.Current.Session[startDirectory] = value;
                //}
            }
    
            public static string CurrentDirectory
            {
                get
                {
                    return GetSessionValue(currentDirectory, false);
                }
                set
                {
                    HttpContext.Current.Session[currentDirectory] = value;
                }
            }
            //TODO: Update to use any class or type
            /// <summary>
            /// Handles routine of getting values out of session and or AppSettings
            /// </summary>
            /// <param name="SessionVar"></param>
            /// <param name="IsAppSetting"></param>
            /// <returns></returns>
            private static string GetSessionValue(string SessionVar, bool IsAppSetting)
            {
                if (null != HttpContext.Current.Session[SessionVar])
                    return (string)HttpContext.Current.Session[SessionVar];
                else if (IsAppSetting)  // Session null with appSetting value
                    return ConfigurationManager.AppSettings[SessionVar];
                else
                    return "";
            }
        }
    }
