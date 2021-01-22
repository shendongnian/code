    using System;
    using System.Web;
    using System.Web.Script.Serialzation;
                public class activityHandler : IHttpHandler
            {
                public void processActivity (HttpContext context) {
                    string message = "{*actor*} played this game";
                    string text = "Play Now";
                    string href = "http://yoururltoplaygamegere";
                    activity act = new activity(message, text, href);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    context.Response.Write(serializer.Serialize(act));
                    context.Response.ContentType = "application/json";
            }
