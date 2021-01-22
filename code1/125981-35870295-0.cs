    @using System.Web.Caching
    @using System.Web.Hosting
    @{
        Layout = "~/Views/Shared/_Layout.cshtml";
        PageData.Add("scriptFormat", string.Format("<script src=\"{{0}}?_={0}\"></script>", GetDeployTicks()));
    }
    @functions
    {
        private static string GetDeployTicks()
        {
            const string cacheKey = "DeployTicks";
            var returnValue = HttpRuntime.Cache[cacheKey] as string;
            if (null == returnValue)
            {
                var absolute = HostingEnvironment.MapPath("~/Web.config");
                returnValue = File.GetLastWriteTime(absolute).Ticks.ToString();
                HttpRuntime.Cache.Insert(cacheKey, returnValue, new CacheDependency(absolute));
            }
            return returnValue;
        }
    }
