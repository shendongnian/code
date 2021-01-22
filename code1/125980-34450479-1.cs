    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString IncludeVersionedJs(this HtmlHelper helper, string filename)
        {
            string version = GetVersion(helper, filename);
            return MvcHtmlString.Create("<script type='text/javascript' src='" + filename + version + "'></script>");
        }
        public static MvcHtmlString IncludeVersionedCss(this HtmlHelper helper, string filename)
        {
            string version = GetVersion(helper, filename);
            return MvcHtmlString.Create("<link href='" + filename + version + "' type ='text/css' rel='stylesheet'/>");
        }
        private static string GetVersion(this HtmlHelper helper, string filename)
        {
            var context = helper.ViewContext.RequestContext.HttpContext;
            var physicalPath = context.Server.MapPath(filename);
            var version = "?v=" +
            new System.IO.FileInfo(physicalPath).LastWriteTime
            .ToString("yyyyMMddHHmmss");
            context.Cache.Add(physicalPath, version, null,
              DateTime.Now.AddMinutes(1), TimeSpan.Zero,
              CacheItemPriority.Normal, null);
            if (context.Cache[filename] == null)
            {
                context.Cache[filename] = version;
                return version;
            }
            else
            {
                if (version != context.Cache[filename].ToString())
                {
                    context.Cache[filename] = version;
                    return version;
                }
                return context.Cache[filename] as string;
            }
        }
    }
