    public static class TimestampedContentExtensions
    {
        public static string VersionedContent(this UrlHelper helper, string contentPath)
        {
            var context = helper.RequestContext.HttpContext;
    
            if (context.Cache[contentPath] == null)
            {
                var physicalPath = context.Server.MapPath(contentPath);
                var version = @"v=" + new FileInfo(physicalPath).LastWriteTime.ToString(@"yyyyMMddHHmmss");
    
                var translatedContentPath = helper.Content(contentPath);
    
                var versionedContentPath =
                    contentPath.Contains(@"?")
                        ? translatedContentPath + @"&" + version
                        : translatedContentPath + @"?" + version;
    
                context.Cache.Add(physicalPath, version, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                    CacheItemPriority.Normal, null);
    
                context.Cache[contentPath] = versionedContentPath;
                return versionedContentPath;
            }
            else
            {
                return context.Cache[contentPath] as string;
            }
        }
    }
