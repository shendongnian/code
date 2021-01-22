ICacheManager cacheManager = CacheFactory.GetCacheManager();
object obj = cacheManager.GetData(YOUROWNCACHEKEY);
YourCMSContentType cmsContent = null;  
if (obj == null)
{
	cmsContent = ""; //get cms content from db here
	cacheManager.Add(YOUROWNCACHEKEY, cmsContent);
}
else
{
	cmsContent = obj as YourCMSContentType;
}  
return cmsContent;
</pre>
