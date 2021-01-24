    using System;
    using System.Web;
    using System.Web.SessionState;
    namespace MyWebApp
    {
        public static class Web
        {
            private static HttpRequest request
            {
                get
                {
                    if (HttpContext.Current == null) return null;
    
                    return HttpContext.Current.Request;
                }
            }
    
            private static HttpResponse response
            {
                get
                {
                    if (HttpContext.Current == null) return null;
    
                    return HttpContext.Current.Response;
                }
            }
    
            private static HttpSessionState session
            {
                get
                {
                    if (HttpContext.Current == null) return null;
    
                    return HttpContext.Current.Session;
                }
            }
    
            public static Person person
            {
                get
                {
                    // Here you can change what is returned when session is not available
                    if (session == null) return null;
                    if(session["Person"] == null) {
                         session["Person"] = new Person();
                    }
                    return session["Person"] as Person;
                }
                set
                {
                    // Here you can change what is returned when session is not available
                    if (session == null) return;
                    session["Person"] = value;
                }
            }
        }
    }
