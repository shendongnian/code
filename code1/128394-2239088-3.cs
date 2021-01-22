    using System;
    using System.Web;
    using System.Web.Script.Serialzation;
         public class activityHandler : IHttpHandler
            {
            public void ProcessRequest (HttpContext context) {
                    string message = "{*actor*} played this game";
                    string text = "Play Now";
                    string href = "http://yoururltoplaygamegere";
                    action_link link = new action_link(text, href);
                    activity act = new activity(message, link);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    context.Response.Write(serializer.Serialize(act));
                    context.Response.ContentType = "application/json";
            }
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
    }
