    using System.Web;
    using umbraco.BusinessLogic;
    namespace Omega.XsltExtensions
    {
        public class Embed
        {
            public static void LogEmbed(int nodeId)
            {
                Log.Add(LogTypes.Open, new User(0), nodeId, "Embedded pano, referer: " + HttpContext.Current.Request.UrlReferrer);
            }
        }
    }
