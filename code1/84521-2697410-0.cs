    public static class XsltHelper
    {
    	/// <summary>
    	/// Returns a compiled XSLT transform object for an XSLT file and caches it
    	/// </summary>
    	/// <param name="XsltFile">The relative path to the XSLT file</param>
    	/// <returns>An XslCompiledTransform object for the XSLT file</returns>
    	public static XslCompiledTransform GetXslt(string XsltFile)
    	{
    		string cacheKey = "macroXslt_" + XsltFile;
    
    		if (System.Web.HttpRuntime.Cache[cacheKey] != null)
    		{
    			return (XslCompiledTransform)System.Web.HttpRuntime.Cache[cacheKey];
    		}
    		else
    		{
    			return GetXSLT(XsltFile, cacheKey);
    		}
    	}
    
    	private static XslCompiledTransform GetXSLT(string XsltFile, string cacheKey)
    	{
    		XslCompiledTransform macroXSLT = new XslCompiledTransform();
    
    		using (XmlTextReader xslReader = new XmlTextReader(System.Web.HttpContext.Current.Server.MapPath(XsltFile)))
    		{
    			try
    			{
    				xslReader.EntityHandling = EntityHandling.ExpandCharEntities;
    				XmlUrlResolver xslResolver = new XmlUrlResolver();
    				xslResolver.Credentials = CredentialCache.DefaultCredentials;
    
    				XsltSettings settings = new XsltSettings();
    				settings.EnableDocumentFunction = true;
    				settings.EnableScript = true;
    				macroXSLT.Load(xslReader, settings, xslResolver);
    
    				System.Web.HttpRuntime.Cache.Insert(cacheKey, macroXSLT,
    					new System.Web.Caching.CacheDependency(System.Web.HttpContext.Current.Server.MapPath(XsltFile)));
    			}
    			catch
    			{
    				throw;
    			}
    		}
    
    		return macroXSLT;
    	}
}
