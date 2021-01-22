	FileInfo info = new FileInfo(fullPath);
	TimeSpan expires = TimeSpan.FromDays(28);
	context.Response.Cache.SetLastModifiedFromFileDependencies();
	context.Response.Cache.SetETagFromFileDependencies();
	context.Response.Cache.SetCacheability(HttpCacheability.Public);
	int status = 200;
	if (context.Request.Headers["If-Modified-Since"] != null)
	{
		status = 304;
		DateTime modifiedSinceDate = DateTime.UtcNow;
		if (DateTime.TryParse(context.Request.Headers["If-Modified-Since"], out modifiedSinceDate))
		{
			modifiedSinceDate = modifiedSinceDate.ToUniversalTime();
			DateTime fileDate = info.LastWriteTimeUtc;
			DateTime lastWriteTime = new DateTime(fileDate.Year, fileDate.Month, fileDate.Day, fileDate.Hour, fileDate.Minute, fileDate.Second, 0, DateTimeKind.Utc);
			if (lastWriteTime != modifiedSinceDate)
				status = 200;
		}
	}
	context.Response.StatusCode = status;
