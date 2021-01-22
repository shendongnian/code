    /// <summary>
    /// This class allows access to the internal MimeMapping-Class in System.Web
    /// </summary>
    class MimeMappingWrapper
    {
    	static MethodInfo getMimeMappingMethod;
    
    	static MimeMappingWrapper() {
    		// dirty trick - Assembly.LoadWIthPartialName has been deprecated
    		Assembly ass = Assembly.LoadWithPartialName("System.Web");
    		Type t = ass.GetType("System.Web.MimeMapping");
    
    		getMimeMappingMethod = t.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic);
    	}
    
    	/// <summary>
    	/// Returns a MIME type depending on the passed files extension
    	/// </summary>
    	/// <param name="fileName">File to get a MIME type for</param>
    	/// <returns>MIME type according to the files extension</returns>
    	public static string GetMimeMapping(string fileName) {
    		return (string)getMimeMappingMethod.Invoke(null, new[] { fileName });
    	}
    }
